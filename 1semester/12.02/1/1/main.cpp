/* Test is Ok - 
			text - asdfas,  line - dfa - result: 3.
							line - afd - result: not include.
*/

#include "iostream"
#include "fstream"
#include "searchSubstring.h"

using namespace std;

int main()
{
	ifstream fin("in.txt");
	char text[1000] = {0};
	fin >> text;
	fin.close();
	char line[100] = {0};
	cout << "Enter string:\n";
	cin >> line;

	int i = searchSubstring(text, line);
	if (i == -1)
		cout << "This line is not included in the text\n";
	else
		cout << "First including - " << i + 1 << endl;
	cout << text << endl << line << endl;
	return 0;
}
