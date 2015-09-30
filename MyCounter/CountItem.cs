using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace MyCounter
{
    [Table]
    class CountItem : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private int _countItemId;
        [Column(IsPrimaryKey=true, IsDbGenerated=true, DbType="INT NOT NULL Identity", CanBeNull=false, AutoSync=AutoSync.OnInsert)]
        public int CountItemId
        {
            get { return _countItemId; }
            set {
                    if (_countItemId != value)
                    {
                        INotifyPropertyChanging("CountItemId");
                        _countItemId = value;
                        INotifyPropertyChanged("CountItemId");
                    }
                }
        }


        [Column]
        private string _countItemTitle;
        public string CountItemTitle
        {
            get{return _countItemTitle;}

            set{
                if (_countItemTitle != value)
                {
                    INotifyPropertyChanging("CountItemTitle");
                    _countItemTitle = value;
                    INotifyPropertyChanged("CountItemTitle");
                }
            }
            
        }


        [Column]
        private int _countItemValue;
        public int CountItemValue
        {
            get { return _countItemValue; }

            set
            {
                if (_countItemValue != value)
                {
                    INotifyPropertyChanging("CountItemValue");
                    _countItemValue = value;
                    INotifyPropertyChanged("CountItemValue");
                }
            }
        }


        [Column]
        private int _countItemStep;
        public int CountItemStep
        {
            get { return _countItemStep; }

            set
            {
                if (_countItemStep != value)
                {
                    INotifyPropertyChanging("CountItemStep");
                    _countItemStep = value;
                    INotifyPropertyChanged("CountItemStep");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;
        private void INotifyPropertyChanging(string p)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(p));
            }
        }
    }
}
