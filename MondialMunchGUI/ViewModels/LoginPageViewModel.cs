using System.Collections.Generic;
using System.Collections.ObjectModel;
using MondialMunch;
using ReactiveUI;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace MondialMunchGUI.ViewModels {
    public class LoginPageViewModel : ViewModelBase {
        private string? _username;
        private string? _password;

        public ReactiveCommand<Unit, User?> Login { get; }
        public ReactiveCommand<Unit, string?> Register { get; }

        public LoginPageViewModel() {
            var isValidObservable = this.WhenAnyValue(
                x => x.Username,
                x => !string.IsNullOrWhiteSpace(x));

            Login = ReactiveCommand.Create(
                () => {
                    User? user = MondialMunchService.GetInstance().GetUserByUsername(Username);
                    if (user == null) return null;
                    if (!user.Authenticate(Password)) return null;
                    return user;
                }, isValidObservable
            );

            Register = ReactiveCommand.Create(
                () => {
                    User? user = MondialMunchService.GetInstance().GetUserByUsername(Username);
                    if (user != null) return null;
                    return Username;
                }
            );
        }

        public string Username {
            get => _username;
            set => this.RaiseAndSetIfChanged(ref _username, value);
        }

        public string Password {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }
    }
}
