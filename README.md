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