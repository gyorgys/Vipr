namespace Microsoft.OneDrive.RestProxy
{
    public interface IStreamFetcher
    {
        string ContentType { get; }
        global::System.Threading.Tasks.Task<StreamResponse> DownloadAsync();
        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        //global::System.Threading.Tasks.Task UploadAsync(global::System.IO.Stream stream, string contentType, bool dontSave = false, bool closeStream = false);
    }
}