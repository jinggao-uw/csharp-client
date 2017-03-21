using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; // make sure this is included
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactApp.Models; // add this on top


namespace ContactApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadContacts(); // call on method when main window is up
        }

        // do this when delete is selected
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null; 
            LoadContacts();
        }

        // check the status of deletion, enable or disable the menu
        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);

            // Exercise: add the context menu deletion IsEnabled here
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        // for deletion: check selection being made
        private ContactModel selectedContact;

        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
        }

        // sorting each column when their header is clicked
        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            // Grab the Tag from the column header
            string sortBy = column.Tag.ToString();

            // Clear out any previous column sorting
            uxContactList.Items.SortDescriptions.Clear();

            // Sort the uxContactList by the column header tag (sortBy)
            // If you want to do Descending, look at the homework :) and SortAdorner
            var sortDescription = new System.ComponentModel.SortDescription(sortBy, 
                System.ComponentModel.ListSortDirection.Ascending);

            uxContactList.Items.SortDescriptions.Add(sortDescription);
        }

        // for context menu
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        // Add the Load Contacts Method
        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());

                LoadContacts(); //when adding call on load contacts to show up
            }
        }
    }
}