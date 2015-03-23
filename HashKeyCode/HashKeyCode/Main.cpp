#include <iostream>
#include "sha1.h"
#include <string>
using namespace std;

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Was trying to make it into a DLL/a wrapper for c# so we could use it. However I seem to be having difficulty doing so.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
int main()
{


	cout << "sha1('grape'):" << sha1("grape") << endl; //This takes the string and creates the hash key
	string key = sha1("grape"); //A way to store it and attent to combine the two keys to create the encryption key?



	system("pause");
}