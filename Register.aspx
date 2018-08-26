<%@ Page Language="C#" Title="Registration" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Register.aspx.cs" Inherits="musicP.register" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" >
        window.onload = function () {
            livePasswordValidator();
            onFocus_displayPasswordStrengthContainer();
        }

        function livePasswordValidator() {
            const tbPassword = document.getElementById("<%= tbPassword.ClientID%>");
            const tbPasswordCheck = document.getElementById("<%= tbPasswordCheck.ClientID%>");
            const charactetLength = document.getElementById("characterLength");
            const lowercaseLetter = document.getElementById("lowercaseLetter");
            const uppercaseLetter = document.getElementById("uppercaseLetter");
            const number = document.getElementById("number");
            const symbol = document.getElementById("symbol");
            const passwordMatch = document.getElementById("passwordMatch");

            tbPassword.addEventListener("keyup", e => {
                const passwordString = tbPassword.value;
                const passwordCheckString = tbPasswordCheck.value;

                characterLengthValidator(passwordString);
                lowercaseLetterValidator(passwordString);
                uppercaseLetterValidator(passwordString);
                numberValidator(passwordString);
                symbolValidator(passwordString);
            });

            tbPasswordCheck.addEventListener("keyup", e => {
                const passwordString = tbPassword.value;
                const passwordCheckString = tbPasswordCheck.value;

                passwordMatchValidator(passwordString, passwordCheckString);
            });

            const characterLengthValidator = (password) => {
                const characterLengthRegex = /^.{8,}$/;

                if (password.match(characterLengthRegex)) {
                    characterLength.classList.remove("invalid");
                    characterLength.classList.add("valid");
                } else {
                    characterLength.classList.remove("valid");
                    characterLength.classList.add("invalid");
                }
            }

            const lowercaseLetterValidator = (password) => {
                const lowercaseLetterRegex = /[a-z]/g;

                if (password.match(lowercaseLetterRegex)) {
                    lowercaseLetter.classList.remove("invalid");
                    lowercaseLetter.classList.add("valid");
                } else {
                    lowercaseLetter.classList.remove("valid");
                    lowercaseLetter.classList.add("invalid");
                }
            }

            const uppercaseLetterValidator = (password) => {
                const uppercaseLetterRegex = /[A-Z]/g;

                if (password.match(uppercaseLetterRegex)) {
                    uppercaseLetter.classList.remove("invalid");
                    uppercaseLetter.classList.add("valid");
                } else {
                    uppercaseLetter.classList.remove("valid");
                    uppercaseLetter.classList.add("invalid");
                }
            }

            const numberValidator = (password) => {
                const numberRegex = /[0-9]/g;

                if (password.match(numberRegex)) {
                    number.classList.remove("invalid");
                    number.classList.add("valid");
                } else {
                    number.classList.remove("valid");
                    number.classList.add("invalid");
                }
            }

            const symbolValidator = (password) => {
                const symbolRegex = /[/?/!@#/$%/^&*]/g;

                if (password.match(symbolRegex)) {
                    symbol.classList.remove("invalid");
                    symbol.classList.add("valid");
                } else {
                    symbol.classList.remove("valid");
                    symbol.classList.add("invalid");
                }
            }

            const passwordMatchValidator = (password, passwordCheck) => {
                if (password === passwordCheck) {
                    passwordMatch.classList.remove("invalid");
                    passwordMatch.classList.add("valid");
                } else {
                    passwordMatch.classList.remove("valid");
                    passwordMatch.classList.add("invalid");
                }
            }
        }

        function onFocus_displayPasswordStrengthContainer() {
            const tbPassword = document.getElementById("<%= tbPassword.ClientID%>");
            const tbPasswordCheck = document.getElementById("<%= tbPasswordCheck.ClientID%>");
            const passwordStrengthContainer = document.getElementById("passwordStrengthContainer");

            tbPassword.addEventListener('focus', e => {
                passwordStrengthContainer.style.display = 'block';
            });

            tbPassword.addEventListener('focusout', e => {
                passwordStrengthContainer.style.display = 'none';
            });

            tbPasswordCheck.addEventListener('focus', e => {
                passwordStrengthContainer.style.display = 'block';
            });

            tbPasswordCheck.addEventListener('focusout', e => {
                passwordStrengthContainer.style.display = 'none';
            });
        }
    </script>

    <div class="center-container login-register-container" >

        <div class="login-register-sub-container">
            <h1 class="login-register">Register</h1>
        </div>

        <div class="login-register-sub-container">
            <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control input-lg" placeholder="Username" />
        </div>

        <div class="login-register-sub-container">
            <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" CssClass="form-control input-lg" placeholder="Password" />
        </div>

        <div class="login-register-sub-container">
            <asp:TextBox ID="tbPasswordCheck" TextMode="Password" runat="server" CssClass="form-control input-lg" placeholder="Re-enter Password" />
        </div>

        <div class="login-register-sub-container">
            <asp:Button ID="btRegister" runat="server" CssClass="btn btn-lg" Text="Register" OnClick="btRegister_Click" />
        </div>

        <div class="login-register-sub-container">
            <asp:LinkButton ID="btLogin" runat="server" OnClick="btLogin_Click">Login</asp:LinkButton>
        </div>

        <div id="passwordStrengthContainer" style="display: none;">
            <p class="invalid" id="characterLength">Minimum of 8 Characters</p>
            <p class="invalid" id="lowercaseLetter">Lowercase Letter</p>
            <p class="invalid" id="uppercaseLetter">Uppercase Letter</p>
            <p class="invalid" id="number">Number</p>
            <p class="invalid" id="symbol">Symbol (?!@#$%^&*)</p>
            <p class="invalid" id="passwordMatch">Passwords Match</p>
        </div>

    </div>
</asp:Content>
