File uploading is one of the most common tasks all developers have to deal with, at some point of their application development cycle. For example, Web applications (such as social networks) usually require users to upload a profile picture during registration or in the case of desktop ones, users may required to upload private documents.

This post will show you how to upload multipart/form-data files using Web API with both Web and Desktop clients. More particular here’s what we gonna see:

- Web API File Upload Controller: Create an action for Uploading multipart-form data
- Web client: Create an AngularJS web client to upload multiple files at once using the Angular File Upload module
- Desktop client: Create an Windows Form client to upload multiple files using HttpClient

Source
- https://chsakell.com/2015/06/07/web-api-file-uploading-desktop-and-web-client/


Open Tasks
- Add SSL
- Protect API using OpenID
- Separate code handling file upload and DTO (FileUploadResult) from request processing / controller

Nice
- Update HTTP client code in desktop client using this example (https://www.strathweb.com/2012/08/a-guide-to-asynchronous-file-uploads-in-asp-net-web-api-rtm/)
- Add progress notification using example code from (https://www.strathweb.com/2012/06/drag-and-drop-files-to-wpf-application-and-asynchronously-upload-to-asp-net-web-api/)


Hypermedia API

Upload Files to Azure Blobs
- Use "Azure Blobs File Upload Sample" from ASP.NET WebApi samples (https://www.asp.net/aspnet/samples/aspnet-web-api)
  - http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/AzureBlobsFileUploadSample/ReadMe.txt
  - AzureBlobMultipartProvider: http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/AzureBlobsFileUploadSample/AzureBlobsFileUpload/BlobStorageStreamProvider/AzureBlobStorageMultipartProvider.cs

Restful interface to ressources/collections
- Support POST/PUT/GET/DELETE
- Document HTTP status code
- Return hypermedia links