/* Test is Ok - 
				4 4
				2 3
				3 2
*/

#include <iostream>
#include "function.h"

using namespace std;

int main()
{
	int powerOne = 0;
	int powerTwo = 0;
	cout << "Enter power of two set:\n";
	cin >> powerOne >> powerTwo;
	
	cout << "Number bijection - " << bijection(powerOne, powerTwo) << endl;
	cout << "Number surjection - " << surjection(powerOne, powerTwo) << endl;
	cout << "Number injection - " << injection(powerOne, powerTwo) << endl;
	return 0;
}

