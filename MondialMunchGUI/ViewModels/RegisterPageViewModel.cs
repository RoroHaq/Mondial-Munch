using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
    public class RegisterPageViewModel : ViewModelBase {
        private string? _username;
        private string? _description;
        public string? _country_origin;
        public string? _country_current;
        private string? _password;
        private string? _check_password;
        public ReactiveCommand<Unit, User?> Register { get; }

        public RegisterPageViewModel(IEnumerable<User> users) {
            ListUsers = new ObservableCollection<User>(users);

            var readyToEnter = this.WhenAnyValue(
                x => x.Username,
                x => x.Password,
                x => x.CheckPassword,
                x => x.Description,
                x => x.CountryOrigin,
                x => x.CountryCurrent,
                (u, p, cp, d, co, cc) => {
                    bool b;
                    b = !string.IsNullOrWhiteSpace(u);
                    b = b && !string.IsNullOrWhiteSpace(p);
                    b = b && !string.IsNullOrWhiteSpace(cp);
                    b = b && !string.IsNullOrWhiteSpace(d);
                    b = b && !string.IsNullOrWhiteSpace(co);
                    b = b && !string.IsNullOrWhiteSpace(cc);
                    b = b && p == cp && p.Length > 3;
                    return b;
                }
            );

            Register = ReactiveCommand.Create(
                () => {
                    foreach (User u in users) {
                        if (u.Name == Username) {
                            return null;
                        }
                    }
                    User user = new(Username, "img/something.png", Description, new Country(CountryOrigin), new Country(CountryCurrent), Password, User.GenerateSalt());
                    //TODO: Instead of new Country fetch it from the DB
                    if (!user.Authenticate(Password)) {
                        return null;
                    }
                    return user;
                }, readyToEnter
            );
        }

        public ObservableCollection<User> ListUsers { get; }

        public string Username {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Description {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public string CountryOrigin {
            get => _country_origin;
            set => this.RaiseAndSetIfChanged(ref _country_origin, value);
        }

        public string CountryCurrent {
            get => _country_current;
            set => this.RaiseAndSetIfChanged(ref _country_current, value);
        }

        public string Password {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string CheckPassword {
            get => _check_password;
            set => this.RaiseAndSetIfChanged(ref _check_password, value);
        }
    }
}
