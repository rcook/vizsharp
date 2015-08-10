// ReverseLinkedList.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

using namespace std;

struct Node
{
    int value;
    Node *next;
};

Node *cons(int value, Node *node)
{
    Node *newNode = new Node;
    newNode->value = value;
    newNode->next = node;
    return newNode;
}

void dump(Node const *node)
{
    for (; node != nullptr; node = node->next)
    {
        cout << node->value << endl;
    }
}

Node *reverse(Node *node)
{
    Node *result = nullptr;

    for (; node != nullptr; node = node->next)
    {
        result = cons(node->value, result);
    }

    return result;
}

int _tmain(int argc, _TCHAR* argv[])
{
    Node *list = cons(1, cons(2, cons(3, cons(4, cons(5, nullptr)))));

    cout << "list:" << endl;
    dump(list);

    Node *reversed = reverse(list);

    cout << "reversed:" << endl;
    dump(reversed);
    return 0;
}

