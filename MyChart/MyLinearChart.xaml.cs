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
    /// Логика взаимодействия для MyLinearChart.xaml
    /// </summary>
    public partial class MyLinearChart : UserControl
    {
        public static readonly DependencyProperty ChartStrokeProperty;
        public static readonly DependencyProperty ChartFillProperty;
        public static readonly DependencyProperty AxisPrimaryStrokeProperty;
        public static readonly DependencyProperty AxisSecondaryStrokeProperty;
        public static readonly DependencyProperty LegendForegroundProperty;

        static MyLinearChart()
        {
            ChartStrokeProperty = DependencyProperty.Register("ChartStroke", typeof(Brush), typeof(MyLinearChart),new PropertyMetadata(Brushes.White));
            ChartFillProperty = DependencyProperty.Register("ChartFill", typeof(Brush), typeof(MyLinearChart), new PropertyMetadata(Brushes.White));
            AxisPrimaryStrokeProperty = DependencyProperty.Register("AxisPrimaryStroke", typeof(Brush), typeof(MyLinearChart), new PropertyMetadata(Brushes.Black));
            AxisSecondaryStrokeProperty = DependencyProperty.Register("AxisSeconderyStroke", typeof(Brush), typeof(MyLinearChart), new PropertyMetadata(Brushes.Black));
            LegendForegroundProperty = DependencyProperty.Register("LegendForeground", typeof(Brush), typeof(MyLinearChart), new PropertyMetadata(Brushes.White));
        }

        public Brush ChartStroke
        {
            get { return (Brush)GetValue(ChartStrokeProperty); }
            set { SetValue(ChartStrokeProperty, value); }
        }

        public Brush ChartFill
        {
            get { return (Brush)GetValue(ChartFillProperty); }
            set { SetValue(ChartFillProperty, value); }
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

        public MyLinearChart()
        {
            InitializeComponent();
        }

    }
}
