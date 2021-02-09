using AXtension.ContentGate.Client;
using AXtension.ContentGate.Client.BusinessEntities;
using AXtension.ContentGate.Client.Content;
using AXtension.ContentGate.Client.ContentCategories;
using AXtension.ContentGate.Client.Infrastructure;
using AXtension.ContentGate.Client.MSAL;
using AXtension.ContentGate.Client.StorageProviders;
using AXtension.ContentGate.Client.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    class UserManager
    {
        // the base uri that references the Content Gate tenant.
        private Uri baseUrl = new Uri("## TENANT ##"); // fill in the tenant. (e.g. https://axtension.content-gate.com)

        // the client id of the app registered in the tenant.
        private string clientId = "## CLIENT ID##"; // fill in the client id here. (e.g. 1bd5690d-2902-4400-b7bb-d292691e6323)

        // the authority that ContentGate belongs to, and accepts signed tokens of.
        private string authority = "## AUTHORITY ##"; // fill in the authority here. (e.g. https://login.microsoftonline.com/axtension.com)

        // for device authentication, simply use the default console output to instruct the user
        // how to authenticate.
        private IDeviceCodeAuthenticationProvider deviceCodeAuthenticator = DeviceAuthentication.Console;

        public async Task GetAllUsers()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                await contentGateClient.Users.GetUsersAsync().ConfigureAwait(false);
            }
        }

        public async Task CreateUser()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                // Define the user to be created.
                var user = new User
                {
                    FirstName = "## FIRST NAME ##",
                    LastName = "## LAST NAME ##",
                    DisplayName = "## DISPLAY NAME ##",
                    UserName = "## USERNAME ##", // e.g. user@example.com
                    UserId = "## AZURE AD USER ID ##" // the id of the user in Azure AD, e.g. 50780F85-1C7A-4959-A4AD-DFF6B161E1A7
                };

                // send the request to Content Gate.
                await contentGateClient.Users.CreateUserAsync(user).ConfigureAwait(false);
            }
        }

        public async Task UpdateUser()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                // Define the user to be updated.
                var user = new UpdateUser
                {
                    Id = long.Parse("## USER ID ##"),
                    FirstName = "## FIRST NAME ##",
                    LastName = "## LAST NAME ##",
                    DisplayName = "## DISPLAY NAME ##",
                };

                // send the request to Content Gate.
                await contentGateClient.Users.UpdateUserAsync(user).ConfigureAwait(false);
            }
        }

        public async Task DeleteUser()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                // The id of the user to be deleted.
                var id = long.Parse("## USER ID ##");

                // send the request to Content Gate.
                await contentGateClient.Users.DeleteUserAsync(id).ConfigureAwait(true);
            }
        }

        public async Task AddRoleToUser()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                // The id of the user to add the specified role to.
                var id = long.Parse("## USER ID ##");

                // The id of the role to be added to the user.
                string roleId = "## ROLE ID ##"; // Fill in the id of the role, e.g. 5fc81f09-a85c-4a43-813f-24de37fd7e6d

                // send the request to Content Gate
                await contentGateClient.Users.AddRoleAsync(id, roleId);
            }
        }

        public async Task RemoveRoleFromUser()
        {
            // construct the client.
            using (var contentGateClient = new ContentGateClient(baseUrl, new ContentGateCredentials(clientId, authority, deviceCodeAuthenticator)))
            {
                // The id of the user to remove the specified role from.
                var id = long.Parse("## USER ID ##");

                // The id of the role to be removed from the user.
                string roleId = "## ROLE ID ##"; // Fill in the id of the role, e.g. 5fc81f09-a85c-4a43-813f-24de37fd7e6d

                // send the request to Content Gate
                await contentGateClient.Users.RemoveRoleAsync(id, roleId);
            }
        }
    }
}
