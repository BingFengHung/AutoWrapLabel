using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoWrapLabel
{
    /// <summary>
    /// AutoWrapLabel.xaml 的互動邏輯
    /// </summary>
    public partial class AutoWrapLabel : UserControl, INotifyPropertyChanged
    {
        public AutoWrapLabel()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private List<string> _segments;
        public List<string> Segments
        {
            get => _segments;
            set
            {
                _segments = value;
                NotifyPropertyChanged(nameof(Segments));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Dependency Properties



        public string Delimiter
        {
            get { return (string)GetValue(DelimiterProperty); }
            set { SetValue(DelimiterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delimiter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DelimiterProperty =
            DependencyProperty.Register("Delimiter", typeof(string), typeof(AutoWrapLabel), new PropertyMetadata(" "));



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AutoWrapLabel), new PropertyMetadata(string.Empty, TextPropertyChanged));


        private static void TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoWrapLabel label = d as AutoWrapLabel;

            string newString = e.NewValue as string;
            var splitString = new string[] { label.Delimiter };
            label.Segments = newString.Split(splitString, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public HorizontalAlignment HorizontalContentAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty); }
            set { SetValue(HorizontalContentAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalContentAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalContentAlignmentProperty =
            DependencyProperty.Register("HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(AutoWrapLabel), new PropertyMetadata(HorizontalAlignment.Center));

        public VerticalAlignment VerticalContentAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalContentAlignmentProperty); }
            set { SetValue(VerticalContentAlignmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalContentAlignment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalContentAlignmentProperty =
            DependencyProperty.Register("VerticalContentAlignment", typeof(VerticalAlignment), typeof(AutoWrapLabel), new PropertyMetadata(VerticalAlignment.Center));

        #endregion
    }
}
