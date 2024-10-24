using System;
using System.Reflection;
using System.Collections.Generic;

public class TypedData
{
	public Type type;
	public object data;
	public FieldInfo[] fieldInfo;

	public TypedData(Type objectType, object objectData, FieldInfo[] objectFieldInfo)
	{
		type = objectType;
		data = objectData;
		fieldInfo = objectFieldInfo;
	}

	public FieldInfo GetField(string fieldName)
	{
		foreach (FieldInfo field in fieldInfo)
			if (field.Name == fieldName)
				return field;
		return null;
	}
}