#pragma once
#ifdef LIBRARYTESTUNITY_EXPORTS
#define LIBRARYTESTUNITY __declspec(dllexport)
#else
#define LIBRARYTESTUNITY __declspec(dllimport)
#endif

using namespace std;


extern "C" {
	 struct TwoStrings {
		const char* string1;
		const char* string2;
		const char* concatenated;

	};
	LIBRARYTESTUNITY TwoStrings FillStruct(TwoStrings tStrings);
}


