/*
10436 무한 유리수 트리
https://www.acmicpc.net/problem/10436

현재 노드에 대해 좌측 자식 노드인 경우엔 p/q 가 p<q 이고 우측 자식인 경우에는 p>q가 성립된다.
이를 통해 부모노드를 구할 수 있고 현재 노드가 어떤 자식 노드인지 확인할 수 있다.

FindNext 의 경우
현재 노드와 부모 노드 모두 왼쪽 노드인 경우 부모노드의 오른쪽 노드가 다음 노드가 된다.
그렇지 않다면 부모 노드가 왼쪽 노드가 될때까지 올라간 다음 해당되는 노드의 다음노드에서 왼쪽노드를 탐색한 만큼 진행한다.
그러면 현재 노드의 다음노드를 구할 수 있다.

하지만 25% 대에서 시간 초과가 발생했다.
1 2147483647/1 를 테스트케이스로 넣는 경우 트리 레벨이 2147483647이고 탐색 방식이 거의 1초라 좀 더 시간을 단축하는 탐색 방식을 찾아봐야할 것 같다.
*/
#include <iostream>
#include <string>
using namespace std;

pair<long,long> GetParent(long p,long q)
{
	if(p>q) // right child
	{
		return {p-q,q};
	}else if(p<q) // left child
	{
		return {p,q-p};
	}
}

bool IsLeftChild(long p,long q)
{
	return p<q;
}

pair<long,long> GetLeftChild(long p,long q)
{
	return {p,q+p};
}

pair<long,long> GetRightChild(long p,long q)
{
	return {q+p,q};
}

pair<long,long> FindNext(long p,long q)
{
	if(p==q)
		return {1,2};
		
	pair<long,long> parent = GetParent(p,q);
	pair<long,long> root;
	long cnt = 0;
	if(IsLeftChild(parent.first,parent.second) && IsLeftChild(p,q))
		return GetRightChild(parent.first,parent.second);
	while(true)
	{
		cnt++;
		if(IsLeftChild(parent.first,parent.second))
		{
			parent = GetParent(parent.first,parent.second);
			root = GetRightChild(parent.first,parent.second);
			break;
		}
		parent = GetParent(parent.first,parent.second);
	}
	while(cnt--)
	{
		root = GetLeftChild(root.first,root.second);
	}
	return {root.first,root.second};
}

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL); cout.tie(NULL);
	int T;
	cin>>T;
	long n,p,q;
	string s;
	for(int i = 0;i<T;i++)
	{
		cin>>n>>s;
		for(int i = 0;i<s.size();i++)
		{
			if(s[i]=='/')
			{
				p = stoll(s.substr(0,i));
				q = stoll(s.substr(i+1));
				break;
			}
		}
		pair<long,long> next = FindNext(p,q);
		cout<<n<<" "<<next.first<<"/"<<next.second<<"\n";
		
	}
	return 0;
}
