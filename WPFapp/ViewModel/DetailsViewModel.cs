using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Linq;

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
    public class DetailsViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the DetailsViewModel class.
        /// </summary>
        public DetailsViewModel(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            Product = new Product();
            Messenger.Default.Register<Product>(this, (product) =>
            {
                Product = product;
            });
            Messenger.Default.Register<String>(this, (type) =>
            {
                Type = type;
            });
        }

        private string _type = "";

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                RaisePropertyChanged();
            }
        }

        private ProductsRepository _productsRepository;

        private Product _product;

        public Product Product
        {
            get => _product;
            set
            {
                _product = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SaveProductCommand => new RelayCommand<Window>(saveProduct);

        private void saveProduct(Window window)
        {
            try
            {
                if (Type == "Add")
                {
                    Product.rowguid = Guid.NewGuid();
                    _productsRepository.AddProduct(Product);
                    Messenger.Default.Send<String>("UpdateData");
                }
                else if (Type == "Edit")
                {
                    _productsRepository.UpdateProduct(Product);
                }
            }
            catch (Exception e)
            {
                string str = Type == "Add" ? "adding" : "editing";
                MessageBox.Show("Sorry, error occured while " + str + " product.", "Error");
            }
            
            window.Close();
        }

        public ICommand CancelCommand => new RelayCommand<Window>(cancel);

        private void cancel(Window window)
        {
            window.Close();
        }
    }
}