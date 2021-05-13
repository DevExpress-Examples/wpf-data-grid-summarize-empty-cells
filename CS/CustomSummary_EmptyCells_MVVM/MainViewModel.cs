using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CustomSummary_EmptyCells_MVVM {
    public class DataItem {
        public string Text { get; set; }
        public int? Number { get; set; }
    }

    public class MainViewModel : ViewModelBase {
        public ObservableCollection<DataItem> Items { get; }
        public MainViewModel() {
            Items = new ObservableCollection<DataItem>(GetItems());
        }
        static IEnumerable<DataItem> GetItems() {
            return Enumerable.Range(0, 100).Select(i => new DataItem() { Text = "group " + i % 10, Number = i % 3 == 0 ? default(int?) : i });
        }

        [Command]
        public void CustomSummary(RowSummaryArgs args) {
            if(args.SummaryItem.PropertyName != "Number")
                return;
            if(args.SummaryProcess == SummaryProcess.Start) {
                args.TotalValue = 0;
            } 
            if(args.SummaryProcess == SummaryProcess.Calculate) {
                if(IsEmptyCell(args.FieldValue))
                    args.TotalValue = (int)args.TotalValue + 1;
            }
        }
        bool IsEmptyCell(object fieldValue) {
            return !((int?)fieldValue).HasValue;
        }
    }
}
