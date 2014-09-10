#include "tree.h"
#include "math.h"
using namespace tree;

ElementType mathOfTree(ListElement *element)
{
	if (element == nullptr)
		return 0;
	ElementType chRight = 0;
	ElementType chLeft = 0;
		
	if (value(left(element)) != '+' && value(left(element)) != '-' &&
		value(left(element)) != '*' && value(left(element)) != '/')
		chLeft = value(left(element));
	else if (value(left(element)) == '+' || value(left(element)) == '-' ||
		value(left(element)) == '*' || value(left(element)) == '/')
		chLeft = mathOfTree(left(element));
		
	if (value(right(element)) != '+' && value(right(element)) != '-' &&
		value(right(element)) != '*' && value(right(element)) != '/')
		chRight = value(right(element));
	else if (value(right(element)) == '+' || value(right(element)) == '-' ||
		value(right(element)) == '*' || value(right(element)) == '/')
		chRight = mathOfTree(right(element));
		
	if (value(element) == '+')
		return chRight + chLeft;
	if (value(element) == '-')
		return chLeft - chRight;
	if (value(element) == '*')
		return chRight * chLeft;
	if (value(element) == '/')
		return chLeft / chRight;
	return 0;
}


int math(Tree *tree)
{
	return mathOfTree(route(tree));
}