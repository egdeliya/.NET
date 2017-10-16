using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ГыукЬфтфпук;

namespace UserManager
{
    // будет отвечать за взаимодействие с пользователем
    public class MainViewModel : DependencyObject
    {
        public SimpleCommand CreateUserCommand { get; set; }
        public SimpleCommand LoadUserCommand { get; set; }
        // команда, которая будет показывать окно пользователя при нажати на кнопку Edit
        public OneParametrCommand<User> EditUserCommand { get; set; }

        //для поиска по имени
        public string FilterString
        {
            get { return (string) GetValue(FilterStringProperty); }
            set { SetValue(FilterStringProperty, value); }
        }

        public static readonly DependencyProperty FilterStringProperty =
            DependencyProperty.Register("FilterStringProperty", typeof (string),
                typeof (MainViewModel), new PropertyMetadata("",
                    delegate(DependencyObject d, DependencyPropertyChangedEventArgs arg)
                    {
                        ((MainViewModel) d).UserList.Refresh();
                    }));

        //для поиска по телефону
        public string FilterPhone
        {
            get { return (string) GetValue(FilterPhoneProperty); }
            set { SetValue(FilterPhoneProperty, value); }
        }

        public static readonly DependencyProperty FilterPhoneProperty =
            DependencyProperty.Register("FilterPhoneProperty", typeof (string),
                typeof (MainViewModel), new PropertyMetadata("",
                    delegate(DependencyObject d, DependencyPropertyChangedEventArgs arg)
                    {
                        ((MainViewModel) d).UserList.Refresh();
                    }));

        //для поиска по почте
        public string FilterEmail
        {
            get { return (string)GetValue(FilterEmailProperty); }
            set { SetValue(FilterEmailProperty, value); }
        }

        public static readonly DependencyProperty FilterEmailProperty =
            DependencyProperty.Register("FilterEmailProperty", typeof(string),
                typeof(MainViewModel), new PropertyMetadata("",
                    // прописываем, чтобы всё изменялось сразу же при изменении
                    delegate (DependencyObject d, DependencyPropertyChangedEventArgs arg)
                    {
                        ((MainViewModel)d).UserList.Refresh();
                    }));

        // для поиска по типу прав доступа
        public string FilterType
        {
            get { return (string)GetValue(FilterTypeProperty); }
            set { SetValue(FilterTypeProperty, value); }
        }

        public static readonly DependencyProperty FilterTypeProperty =
            DependencyProperty.Register("FilterTypeProperty", typeof(string),
                typeof(MainViewModel), new PropertyMetadata("",
                    delegate (DependencyObject d, DependencyPropertyChangedEventArgs arg)
                    {
                        ((MainViewModel)d).UserList.Refresh();
                    }));


        public ICollectionView UserList
        {
            get { return (ICollectionView) GetValue(UserListProperty); }
            set { SetValue(UserListProperty, value); }
        }

        public static readonly DependencyProperty UserListProperty =
            DependencyProperty.Register("UserList", typeof (ICollectionView),
                typeof (MainViewModel), new PropertyMetadata(null));

        public MainViewModel()
        {
            //UserList = new ICollectionView(User.GetUserts());
            var ls = new ObservableCollection<User>();
            UserList = CollectionViewSource.GetDefaultView(ls);

            UserList.Filter += FilterUser;

            CreateUserCommand = new SimpleCommand(CreateUser);
            LoadUserCommand = new SimpleCommand(LoadUsers);
            EditUserCommand = new OneParametrCommand<User>(EditUser);
        }

        // для редактирования пользователей
        private void EditUser(User user)
        {
            var window = new UserWindow();
            window.DataContext = new UserWindowViewModel
            {
                User = user
            };

            window.Show();
        }

        public void CreateUser()
        {
            var obsLs = UserList.SourceCollection as ObservableCollection<User>;
            obsLs.Add(new User() {Name = "name"});
        }

        public void LoadUsers()
        {
            var ls = new ObservableCollection<User>(User.GetUserts());
            UserList = CollectionViewSource.GetDefaultView(ls);
            UserList.Filter += FilterUser;
        }

        private bool FilterUser(object obj)
        {
            var user = obj as User;
            if (user == null)
            {
                return false;
            }

            bool correctType = false;
            switch (FilterType)
            {
                case "Любые":
                    correctType = true;
                    break;
                case "Админ":
                    correctType = user.Type == UserType.Admin;
                    break;
                case "Модератор":
                    correctType = user.Type == UserType.Moderator;
                    break;
                case "Пользователь":
                    correctType = user.Type == UserType.User;
                    break;
                default:
                    correctType = false;
                    break;
            }
            if (!string.IsNullOrEmpty(FilterType) && !correctType)
                return false;
            if (!string.IsNullOrEmpty(FilterPhone) && !user.Phone.Contains(FilterPhone))
                return false;
            if (!string.IsNullOrEmpty(FilterString) && !user.Name.Contains(FilterString))
                return false;
            if (!string.IsNullOrEmpty(FilterEmail) && !user.Email.Contains(FilterEmail))
                return false;

            return true;
        }
    }

}
