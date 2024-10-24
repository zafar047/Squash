using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataFileManager
{
	string location;

	public DataFileManager(string directory)
	{
		location = directory;
	}

	public bool isExist()
	{
		return File.Exists(location);
	}

	public void saveData(object SaveClassReference)
	{
		FileStream saveStream = new FileStream(location, FileMode.Create, FileAccess.Write);
		BinaryFormatter formatter = new BinaryFormatter();
		formatter.Serialize(saveStream, SaveClassReference);
		saveStream.Close();
	}

	public object loadData()
	{
		FileStream loadStream = new FileStream(location, FileMode.Open, FileAccess.Read);
		BinaryFormatter formatter = new BinaryFormatter();
		object obj = formatter.Deserialize(loadStream);
		loadStream.Close();
		return obj;
	}
}