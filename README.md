# AXtension® Content Gate Samples
This repository contains sample applications for external use of the AXtension® Content Gate client SDK using the REST endpoints provided by AXtension® Content Gate.

## How to run this sample
To run this sample:

Install .NET Core for Windows by following the instructions at .NET and C# - Get Started in 10 Minutes. In addition to developing on Windows, you can develop on Linux, Mac, or Docker.

An Azure AD tenant. 
For more information on how to obtain an Azure AD tenant, see How to get an Azure AD tenant.

### Step 1: Register the sample with your Azure AD tenant
1. Sign in to the [Azure portal](https://portal.azure.com/).

2. On the top bar, select your account. Under the **DIRECTORY** list, choose the Active Directory tenant where you wish to register your app. If there isn't a **DIRECTORY** list in the drop down menu, skip this step, as you only have a single tenant associated with your Azure account. For more information, see [How to get an Azure Active Directory tenant.](https://docs.microsoft.com/azure/active-directory/develop/active-directory-howto-tenant)

3. In the left navigation sidebar, select **Azure Active Directory**. If you don't see **Azure Active Directory** in the list, select **More Services** and choose **Azure Active Directory** in the **SECURITY + IDENTITY** section of the service list.

4. From the sidebar, select **App registrations**.

5. Select **New application registration** and provide a friendly name for the app, app type, and sign-on URL: 
      - **Name:** ContentGateUploadApp
      - **Supported account types:** Single tenant
      - **Redirect URI:** Public client/native (mobile & desktop) with **Sign-on URL:** `local://content-gate.local/signin-oidc`
    
    Select **Register** to register the app.

    For more information about registering an application please visit: [Quickstart register app](https://docs.microsoft.com/nl-nl/azure/active-directory/develop/quickstart-register-app).

6. From the Azure portal, note the following information:

   - **The Tenant domain:** See the **App ID URI** base URL. For example: `contoso.onmicrosoft.com`
   - **The Tenant ID:** See the **Endpoints** blade. Record the GUID from any of the endpoint URLs. For example: `1bd5690d-2902-4400-b7bb-d292691e6323`
   - **The Application ID (Client ID):** See the Properties blade. For example: `ba74781c2-53c2-442a-97c2-3d60re42f403`

### Step 2: Run the sample
Fill the values commented out in code (e.g. client id, authority etc)

## How to authenticate
There are five methods availible to authenticate to the Content Gate Client. See the description of these methods below.
To create a ContentGateClient object you will need a ContentGateCredentials object. It has multiple constructors for the following flows.

For sample code see the authentication solution: [Authentication samples](https://github.com/axtension/contentgate-samples/tree/AddAuthenticationSample/Authentication).

### User Prompt flow
The user will be prompted a login screen.

**Example**: 
```C#
new ContentGateClient('## TENANT ##', new ContentGateCredentials('## CLIENT ID ##', '## AUTHORITY ##'));
```
### Device Code flow
Allows users to sign in to input-constrained devices. 

**Example**: 
```C#
new ContentGateClient('## TENANT ##', new ContentGateCredentials('## CLIENT ID ##', '## AUTHORITY ##', DeviceAuthentication.Console));
```

### Service Account flow
Allows you to access the client by using the identity of an application, this without immediate interaction with a user.

**Example**: 
```C#
**Example**: new ContentGateClient('## TENANT ##', new ContentGateCredentials('## CLIENT ID ##', '## AUTHORITY ##', '## CLIENT SECRET ##'));
```

### Username/Password flow
Allows you to sign in the user by directly handling their password. **This flow isn't recommended.**

**Example**: 
```C#
**Example**: new ContentGateClient('## TENANT ##', new ContentGateCredentials('## CLIENT ID ##', '## AUTHORITY ##', '## USERNAME ##', '## PASSWORD ##'));
```

### Custom Content Gate Credentials
There is also a possibility to ceate a custom content gate credentials class, this can be achieved by creating a new class (e.g. CustomContentGateCredentials) and implementing the IContentGateCredentials interface with the corresponding methods.

**Example**: 
```C#
**Example**: new ContentGateClient('## TENANT ##', new CustomContentGateCredentials('## CLIENT ID ##', '## AUTHORITY ##'));
```