using System.ComponentModel;

namespace PieChart
{
    public class PieCharItem : INotifyPropertyChanged
    {
        private string _typeName;
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get { return _typeName; }
            set
            {
                if(_typeName != value)
                {
                    _typeName = value;
                    OnPropertyChanged("TypeName");
                }
            }
        }

        private int _typeNumber;
        /// <summary>
        /// 类型数量
        /// </summary>
        public int TypeNumber
        {
            get { return _typeNumber; }
            set
            {
                if(_typeNumber != value)
                {
                    _typeNumber = value;
                    OnPropertyChanged("TypeNumber");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
