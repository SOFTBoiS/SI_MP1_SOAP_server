# SI_MP1_SOAP_SERVER

## Requirements
API key to pexels.com  
Visual studio 2019   
.Net framework 4.7.2 or higher

## Steps to run program
Note: If it complains about JObject build errors, reinstall Newtonsoft.JSON nuget package
1. Add user secrets
  1.1 Right click on SOAPE_Exercise_Server and click manage user secrets
  1.2 Add this into your xml with your API key
  ```
  <?xml version="1.0" encoding="utf-8"?>
  <root>
  <secrets ver="1.0">
    <secret name="APIKey">YOUR_API_KEY_HERE</secret>
  </secrets>
  </root>
  ```
 2. Run project
