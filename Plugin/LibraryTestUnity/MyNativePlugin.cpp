#include "pch.h"
#include "MyNativePlugin.h"
#pragma warning(disable : 4996)


LIBRARYTESTUNITY TwoStrings FillStruct(TwoStrings tString)
{
	auto str1 = tString.string1;
	auto str2 =  tString.string2;

	auto c = new char[strlen(str1) + strlen(str2) + 1];
	strcpy(c, str1);
	strcat(c, str2);
	TwoStrings myStruct = TwoStrings{ str1,str2,c};

	return  myStruct;
}
