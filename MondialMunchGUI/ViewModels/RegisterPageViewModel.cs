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
        public Country? _country_origin;
        public Country? _country_current;
        private string? _password;
        private string? _check_password;
        public ReactiveCommand<Unit, User?> Register { get; }
        public ReactiveCommand<Unit, Unit> Back { get; }

        public RegisterPageViewModel() {
            Countries = MondialMunchService.GetInstance().GetCountries();

            var readyToEnter = this.WhenAnyValue(
                x => x.Username,
                x => x.Password,
                x => x.CheckPassword,
                x => x.Description,
                x => x.CountryOrigin,
                x => x.CountryCurrent,
                (username, password, checkPassword, description, countryOrigin, countryCurrent) => {
                    return !string.IsNullOrWhiteSpace(username)
                    && !string.IsNullOrWhiteSpace(password)
                    && !string.IsNullOrWhiteSpace(checkPassword)
                    && !string.IsNullOrWhiteSpace(description)
                    && password == checkPassword && password.Length > 3;
                }
            );

            Register = ReactiveCommand.Create(
                () => {
                    User? existingUser = MondialMunchService.GetInstance().GetUserByUsername(Username);
                    if (existingUser != null) return null;

                    User user = new(Username, "https://i.imgur.com/JCoYjzH.png", Description, CountryOrigin, CountryCurrent, Password, User.GenerateSalt());
                    if (!user.Authenticate(Password)) return null;
                    return user;
                }, readyToEnter
            );

            Back = ReactiveCommand.Create(
                () => { return new Unit(); }
            );
        }

        public List<Country> Countries { get; }

        public string Username {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Description {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public Country CountryOrigin {
            get => _country_origin;
            set => this.RaiseAndSetIfChanged(ref _country_origin, value);
        }

        public Country CountryCurrent {
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
