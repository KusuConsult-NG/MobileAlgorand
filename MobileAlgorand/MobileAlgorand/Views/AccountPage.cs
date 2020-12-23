using Algorand;
using Algorand.V2;
using MobileAlgorand.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileAlgorand.Views
{
    public class AccountPage : ContentPage
    {
        private Entry address;
        private Entry balance;
        private Entry key;
        public string StorageAccountName1 = "Account 1";
        public string StorageAccountName2 = "Account 2";
        public string StorageAccountName3 = "Account 3";
        public AccountPage()
        {
            this.Title = "Account Address Page";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Check Account Address Balance";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);
            address = new Entry();
            address.Placeholder = "Address Here..";
            address.Keyboard = Keyboard.Default;
            stackLayout.Children.Add(address);
            balance = new Entry();
            balance.Placeholder = "Balance Here..";
            balance.Keyboard = Keyboard.Default;
            stackLayout.Children.Add(balance);
            key = new Entry();
            key.Placeholder = "Key Here..";
            key.Keyboard = Keyboard.Default;
            stackLayout.Children.Add(key);
            Button button2 = new Button();
            button2.Text = "Generate Account Address";
            button2.Clicked += Button2_Clicked;
            stackLayout.Children.Add(button2);
            Content = stackLayout;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string ALGOD_API_ADDR_TESTNET = "https://testnet-algorand.api.purestake.io/ps2";
            string ALGOD_API_TOKEN_TESTNET = "B3SU4KcVKi94Jap2VXkK83xx38bsv95K5UZm2lab";
            AlgodApi algodApiInstances = new AlgodApi(ALGOD_API_ADDR_TESTNET, ALGOD_API_TOKEN_TESTNET);
            var c = address.Text; //"VTUAQ64NZU2JSX2PJVDN7GGEOB7AQLQFLVUNMIJPZHBRYF4L5TR6SZGGJM";
            var accountInfo = algodApiInstances.AccountInformation(c.ToString());
            balance.Text = $"{accountInfo.Amount}";
            await DisplayAlert("Account Address", $"MicroAlgos: {accountInfo.Amount}", "OK");
            
        }
        //design syrup fox setup pledge flock over please engine admit pull mirror suspect they nerve leaf naive appear insane rather hope alpha media ability elegant
        //GZTJNTP3DAU5KYNYHWQVHIAHY6MZX63WSRBCIWA3Z7WGYQVUNLLXOQ3ADI
        private void Button2_Clicked(object sender, EventArgs e)
        {
            Account account = new Account();
            AccountClass accountClass = new AccountClass()
            {
                Address = address.Text = account.Address.ToString(),
                Key = key.Text = (account.ToMnemonic())
            };
        }

        public async Task<Account[]> RestoreAccounts()
        {
            Account[] accounts = new Account[3];

            string mnemonic1 = "";
            string mnemonic2 = "";
            string mnemonic3 = "";

            try
            {
                mnemonic1 = await SecureStorage.GetAsync(StorageAccountName1);
                mnemonic2 = await SecureStorage.GetAsync(StorageAccountName2);
                mnemonic3 = await SecureStorage.GetAsync(StorageAccountName3);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                // Possible that device doesn't support secure storage on device.
            }
            // restore accounts
            accounts[0] = new Account(mnemonic1);
            accounts[1] = new Account(mnemonic2);
            accounts[2] = new Account(mnemonic3);
            return accounts;


        }
    }
}