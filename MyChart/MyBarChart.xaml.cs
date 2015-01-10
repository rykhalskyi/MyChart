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

namespace MyChart
{
    /// <summary>
    /// Логика взаимодействия для MyBarChart.xaml
    /// </summary>
    public partial class MyBarChart : UserControl
    {
        public static readonly DependencyProperty DefaultFillProperty;
        public static readonly DependencyProperty SelectedFillProperty;
        public static readonly DependencyProperty AxisPrimaryStrokeProperty;
        public static readonly DependencyProperty AxisSecondaryStrokeProperty;
        public static readonly DependencyProperty LegendForegroundProperty;

        static MyBarChart()
        {
            DefaultFillProperty = DependencyProperty.Register("DefaultFill", typeof(Brush), typeof(MyBarChart), new PropertyMetadata(Brushes.White));
            SelectedFillProperty = DependencyProperty.Register("SelectedFill", typeof(Brush), typeof(MyBarChart), new PropertyMetadata(Brushes.White));
            AxisPrimaryStrokeProperty = DependencyProperty.Register("AxisPrimaryStroke", typeof(Brush), typeof(MyBarChart), new PropertyMetadata(Brushes.Black));
            AxisSecondaryStrokeProperty = DependencyProperty.Register("AxisSeconderyStroke", typeof(Brush), typeof(MyBarChart), new PropertyMetadata(Brushes.Black));
            LegendForegroundProperty = DependencyProperty.Register("LegendForeground", typeof(Brush), typeof(MyBarChart), new PropertyMetadata(Brushes.White));
        }

        public Brush DefaultFill
        {
            get { return (Brush)GetValue(DefaultFillProperty); }
            set { SetValue(DefaultFillProperty, value); }
        }

        public Brush SelectedFill
        {
            get { return (Brush)GetValue(SelectedFillProperty); }
            set { SetValue(SelectedFillProperty, value); }
        }

        public Brush AxesPrimaryStroke 
        {
            get { return (Brush)GetValue(AxisPrimaryStrokeProperty); }
            set { SetValue(AxisPrimaryStrokeProperty, value); }
        }

        public Brush AxesSecondaryStroke
        {
            get { return (Brush)GetValue(AxisSecondaryStrokeProperty); }
            set { SetValue(AxisSecondaryStrokeProperty, value); }
        }

        public Brush LegendForeground
        {
            get { return (Brush)GetValue(LegendForegroundProperty); }
            set { SetValue(LegendForegroundProperty, value); }
        }

        public MyBarChart()
        {
            InitializeComponent();
        }
    }
}
