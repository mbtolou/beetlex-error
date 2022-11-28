using System.Security.Cryptography;
using BeetleX.FastHttpApi;

[Controller(BaseUrl = "api/test-upload/")]
class TestApi
{
	[Post]
	public object upload(IHttpContext context)
	{
		foreach (var file in context.Request.Files)
			using (var md5 = MD5.Create())
			{
				return Convert.ToHexString(md5.ComputeHash(file.Data));
			}
		return context.Request.Files.Count;
	}
}