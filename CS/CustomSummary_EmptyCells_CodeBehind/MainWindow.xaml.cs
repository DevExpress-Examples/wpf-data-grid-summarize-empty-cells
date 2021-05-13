using DevExpress.Data;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomSummary_EmptyCells_CodeBehind {
    public class DataItem {
        public string Text { get; set; }
        public int? Number { get; set; }
    }

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = GetItems().ToList();
        }
        static IEnumerable<DataItem> GetItems() {
            return Enumerable.Range(0, 100).Select(i => new DataItem() { Text = "group " + i % 10, Number = i % 3 == 0 ? default(int?) : i });
        }

        void OnCustomSummary(object sender, CustomSummaryEventArgs e) {
            if(((GridSummaryItem)e.Item).FieldName != "Number")
                return;
            if(e.SummaryProcess == CustomSummaryProcess.Start) {
                e.TotalValue = 0;
            }
            if(e.SummaryProcess == CustomSummaryProcess.Calculate) {
                if(IsEmptyCell(e.FieldValue))
                    e.TotalValue = (int)e.TotalValue + 1;
            }
        }
        bool IsEmptyCell(object fieldValue) {
            return !((int?)fieldValue).HasValue;
        }
    }
}
