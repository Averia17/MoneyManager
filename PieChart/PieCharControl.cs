using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PieChart
{
    [TemplatePart(Name = Parid_timePoint)]
    [TemplatePart(Name = Parid_legendGrid)]
    public class PieCharControl : Control
    {
        private Grid _timePoint;                             
        private StackPanel _legendGrid;                   
        private ListView _legendGridView;                   
        private TextBlock _titleText;                        

        private const string Parid_timePoint = "Z_Parid_timePoint";
        private const string Parid_titleText = "Z_Parid_titleText";
        private const string Parid_legendGrid = "Z_Parid_legendGrid";
        private const string Parid_legendGrid_View = "Z_Parid_legendGrid_View";

        
        public static readonly DependencyProperty PieItemSourcesProperty = DependencyProperty.Register(
            "PieItemSources",
            typeof(ObservableCollection<PieCharItem>),
            typeof(PieCharControl),
            new PropertyMetadata(null, OnPieItemSourcesChanged, CoerceTMethod));

       
        public ObservableCollection<PieCharItem> PieItemSources
        {
            get { return (ObservableCollection<PieCharItem>)GetValue(PieItemSourcesProperty); }
            set { SetValue(PieItemSourcesProperty, value); }
        }

        private static PieCharControl _masterPieChar;

        private List<SolidColorBrush> _colorBrushList;
        private List<SolidColorBrush> ColorBrushList
        {
            get
            {
                if (_colorBrushList == null || _colorBrushList.Count == 0)
                {
                    _colorBrushList = new List<SolidColorBrush>()
                    {
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A121FD")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB6C20")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DF1E1E")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e048a3")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8fb5b2")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e6cf0d")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8346e0")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e6cf0d")),
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString("#99b54e"))
                    };
                }
                return _colorBrushList;
            }
        }

        private static void OnPieItemSourcesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PieCharControl pieControl = (PieCharControl)d;
            _masterPieChar = pieControl;
            if (pieControl.PieItemSources != null && pieControl.PieItemSources.Count() > 0)
            {
                pieControl.PieItemSources.CollectionChanged += PieItemSources_CollectionChanged;
                foreach (var item in pieControl.PieItemSources)
                {
                    item.PropertyChanged += Obj_PropertyChanged;
                }
                pieControl.ConstDataPie();
            }
        }

        private static void PieItemSources_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (PieCharItem item in e.NewItems)
                {
                    item.PropertyChanged += Obj_PropertyChanged;
                }
            }
            _masterPieChar.ConstDataPie();
        }

        private static void Obj_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _masterPieChar.ConstDataPie();
        }

        private static object CoerceTMethod(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnAggregateNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PieCharControl pieControl = (PieCharControl)d;
            if (pieControl.PieItemSources != null && pieControl.PieItemSources.Count() > 0)
            {
                pieControl.ConstDataPie();
            }
        }

        private static object CoerceAggregateName(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _timePoint = GetTemplateChild(Parid_timePoint) as Grid;
            _titleText = GetTemplateChild(Parid_titleText) as TextBlock;
            _legendGrid = GetTemplateChild(Parid_legendGrid) as StackPanel;
            _legendGridView = GetTemplateChild(Parid_legendGrid_View) as ListView;

        }

        public PieCharControl()
        {
            SizeChanged += delegate { ConstDataPie(); };
        }

        public void ConstDataPie()
        {
            if (_timePoint != null)
            {
                //TODO БАГ ПРИ СМЕНЕ ДНЯ
                SetDefaultChild();
                List<SectorPart> sectorParts = new List<SectorPart>();                                                        
                int allNumber = PieItemSources == null ? 0 : PieItemSources.Sum(x => x.TypeNumber);      
                if (allNumber > 0)
                {

                    foreach (var item in PieItemSources)
                    {
                        int colorCount = sectorParts.Count();
                        double Z_angle = (double)item.TypeNumber / allNumber * 360;
                        sectorParts.Add(new SectorPart(Z_angle >= 360 ? 359.99 : Z_angle, ColorBrushList[colorCount]));

                        AddIconFill(ColorBrushList[colorCount], allNumber, item);

                    }
                }
                foreach (var shape in GetEllipsePieChartShapes(GetPieCenterPoint(), GetPieWidth(), GetPieWidth(), 0, sectorParts))
                {
                    _timePoint.Children.Add(shape);
                }
            }
        }

        private void SetDefaultChild()
        {
            _timePoint.Children.Clear();
            _legendGridView.Items.Clear();
        }
        private void AddIconFill(Brush color, int allNumber, PieCharItem item)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(new Ellipse()
            {
                Fill = color,
                Width = 15,
                Height = 15,
                Margin = new Thickness(10, 0, 5, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            });
            stackPanel.Children.Add(new TextBox()
            {
                Text = $"{item.TypeName}({(Math.Round((double)item.TypeNumber / allNumber * 100, 1)).ToString("F1")}%)",
                FontSize = 15,
                IsReadOnly = true,
                BorderThickness = new Thickness(0),
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Center,
            });
           // ListViewItem listViewItem = new ListViewItem(stackPanel);
            _legendGridView.Items.Add(stackPanel);
        }

        public Point GetPieCenterPoint()
        {
            return new Point(_timePoint.ActualWidth / 2, _timePoint.ActualHeight / 2);
        }

        public double GetPieWidth()
        {
            double Z_width = _timePoint.ActualWidth > _timePoint.ActualHeight ? (_timePoint.ActualHeight / 2 - 20) : (_timePoint.ActualWidth / 2 - 20);
            return Z_width < 0 ? 10 : Z_width;
        }

        static PieCharControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PieCharControl), new FrameworkPropertyMetadata(typeof(PieCharControl)));
        }
        public static Point GetEllipsePointAnti(Point center, double radiusX, double radiusY, double angle)
        {
            Vector circleZeroAnglePoint = new Vector(0, radiusX);                                           
            Matrix rotateMatrix = new Matrix();                                                              
            rotateMatrix.Rotate(180 + angle);
            Vector circlePoint = circleZeroAnglePoint * rotateMatrix;                                      
            Point ellpseOrigin = new Point(circlePoint.X, circlePoint.Y * radiusY / radiusX);          

            return (Vector)ellpseOrigin + center;                                                                       
        }

        public static IEnumerable<Shape> GetEllipsePieChartShapes(Point center, double radiusX, double radiusY, double offsetAngle, IEnumerable<SectorPart> sectorParts)
        {
            var shapes = new List<Shape>();
            foreach (var sectorPart in sectorParts)
            {
                Point firstPoint = GetEllipsePointAnti(center, radiusX, radiusY, offsetAngle);            
                offsetAngle += sectorPart.SpanAngle;

                Point secondPoint = GetEllipsePointAnti(center, radiusX, radiusY, offsetAngle);        
                PathFigure sectorFigure = new PathFigure { StartPoint = center };

                sectorFigure.Segments.Add(new LineSegment(firstPoint, false));                               

                sectorFigure.Segments.Add(
                    new ArcSegment
                    {
                        Point = secondPoint,
                        Size = new Size(radiusX, radiusY),
                        RotationAngle = 0,
                        IsLargeArc = sectorPart.PIsLargeArc,
                        SweepDirection = SweepDirection.Clockwise,
                        IsStroked = false
                    });
                PathGeometry sectorGeometry = new PathGeometry();
                sectorGeometry.Figures.Add(sectorFigure);
                Path sectorPath = new Path { Data = sectorGeometry, Fill = sectorPart.FillBrush };
                shapes.Add(sectorPath);
            }
            return shapes;
        }
    }
}