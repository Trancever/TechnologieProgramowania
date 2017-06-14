using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Linq;
using WPFapp.Views;

namespace WPFapp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            updateData();
            Messenger.Default.Register<string>(this, (message) =>
            {
                UpdateView = message;
            });
        }

        private string _updateView = "";

        public string UpdateView
        {
            set
            {
                _updateView = value;
                if (value == "UpdateData")
                {
                    updateData();
                }
            }
        }

        private void updateData()
        {
            try
            {
                Products = new ObservableCollection<Product>(_productsRepository.GetProducts());
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't connect to Database, displaying empty list", "Error");
            }
        }

        private ProductsRepository _productsRepository;

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged();
            }
        }

        public ICommand RemoveProductCommand => new RelayCommand(() => removeProduct());

        private void removeProduct()
        {
            if (Product == null)
            {
                MessageBox.Show("You have to select element on the list first.", "Warning");
                return;
            }
            try
            {
                _productsRepository.DeleteProduct(Product);
                updateData();
            }
            catch (Exception e)
            {
                MessageBox.Show("Problem occured while removing product", "Error");
            }
        }

        public ICommand EditProductCommand => new RelayCommand(() => editProduct());

        private void editProduct()
        {
            if (Product == null)
            {
                MessageBox.Show("You have to select element on the list first.", "Warning");
                return;
            }
            DetailsWindow window = new DetailsWindow();
            window.ShowDialog();
            Messenger.Default.Send<Product>(Product);
            Messenger.Default.Send<string>("Edit");
        }

        public ICommand AddProductCommand => new RelayCommand(() => addProduct());

        private void addProduct()
        {
            DetailsWindow window = new DetailsWindow();
            window.Show();
            Messenger.Default.Send<string>("Add");
        }
    }
}