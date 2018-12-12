# AXtension® Content Gate Samples
This repository contains sample applications for external use of the AXtension® Content Gate client sdk using the REST endpoints provided by AXtension® Content Gate.

## How to run this sample
To run this sample:

Install .NET Core for Windows by following the instructions at .NET and C# - Get Started in 10 Minutes. In addition to developing on Windows, you can develop on Linux, Mac, or Docker.
An Azure AD tenant. For more information on how to obtain an Azure AD tenant, see How to get an Azure AD tenant.

### Step 1: Register the sample with your Azure AD tenant
1. Sign in to the [Azure portal](https://portal.azure.com/).

2. On the top bar, select your account. Under the **DIRECTORY** list, choose the Active Directory tenant where you wish to register your app. If there isn't a **DIRECTORY** list in the drop down menu, skip this step, as you only have a single tenant associated with your Azure account. For more information, see [How to get an Azure Active Directory tenant.](https://docs.microsoft.com/azure/active-directory/develop/active-directory-howto-tenant)

3. In the left navigation sidebar, select **Azure Active Directory**. If you don't see **Azure Active Directory** in the list, select **More Services** and choose **Azure Active Directory** in the **SECURITY + IDENTITY** section of the service list.

4. From the sidebar, select **App registrations**.

5. Select **New application registration** and provide a friendly name for the app, app type, and sign-on URL: 
      - **Name:** ContentGateUploadApp
      - **Application Type:** Natvie 
      - **Sign-on URL:** `local://content-gate.local/signin-oidc`
    
    Select **Create** to register the app.

6. From the Azure portal, note the following information:

   - **The Tenant domain:** See the **App ID URI** base URL. For example: `contoso.onmicrosoft.com`
   - **The Tenant ID:** See the **Endpoints** blade. Record the GUID from any of the endpoint URLs. For example: `1bd5690d-2902-4400-b7bb-d292691e6323`
   - **The Application ID (Client ID):** See the Properties blade. For example: `ba74781c2-53c2-442a-97c2-3d60re42f403`

### Step 2: Run the sample
Fill the values commented out in code (e.g. client id, authority etc)
