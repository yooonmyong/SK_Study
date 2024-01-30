/*
14565 역원(Inverse) 구하기
https://www.acmicpc.net/problem/14565

확장된 유클리드 알고리즘 사용 문제
*/
#include <iostream>
using namespace std;

long long ExtendedEuclidean(long long a,long long b,long long &s,long long &t) 
{
	if (!b)
	{
		s = 1, t = 0;
		return a;
	}
	
	long long q = a/b, r = a%b, sp, tp;
	long long g = ExtendedEuclidean(b,r,sp,tp);
	s = tp;
	t = sp-tp*q;
	
	return g;
}


int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL); cout.tie(NULL);
	long long x,y,N, A;
	cin >> N >> A;
	cout<<N-A<<" ";
	long long g = ExtendedEuclidean(A, N, x, y);
	if (g != 1)
	{
		cout << -1;
		return 0;
	}else{
		x = (x + N) % N;
		cout << x;		
	}

	return 0;
}