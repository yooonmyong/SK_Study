/*
14848 정수 게임
https://www.acmicpc.net/problem/14848

첫 시도에서는 먼저 문제에 나온대로 각 수의 배수를 제거하고 중복 제거를 없애기위해 각 배수 집합에 대해 3C2의 조합을 구해 구한 조합내 최대 공약수를 구해 해당되는 집합의 크기를 구한뒤 하나씩 더해주었다.
10 + (- 5 - 2 - 2) + (2 + 1 + 0) 예제는 맞았지만 일반화 하지 못하고 고민하다가 알고리즘 분류를 보고 "포함 배제의 원리"에 대해서 찾아보았다.

포함 배제의 원리란
조합론에서 포함배제의 원리는 유한 집합의 합집합의 원소 개수를 세는 기법이다.
일반화된 공식은 모든 교집합의 경우의 수를 구해 교집합의 개수가 홀수면 더하고 겹치는 부분이 짝수이면 빼면 된다. 

해당 문제의 예제 같은 경우에는 아래와 풀이가 포함 배제의 원리에 따라 진행된다.
kCn
3C1 : {2},{4},{5} 
3C2 : {2,4},{2,5},{4,5}
3C3 : {2,4,5}
(5 + 2 + 2) - (2,1,0) + (0) = 6
이와같이 전체 N 10에 대해서 구한 합집합의 원소의 개수인 6를 빼주면 답을 구할 수 있다.

다만, 이때 최대 공약수를 구할때 자료형에 유의해야한다.
K = 15 이다보니 100보다 작아도 곱하다보면 int 범위를 넘어서기 때문이다.
https://www.acmicpc.net/board/view/32330


🧷 reference : https://zzonglove.tistory.com/35
*/
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

// 최소 공배수
// 이때 a의 값이 언제나 b보다 커야 최소 공배수가 나온다.
long long gcd(long long a, long long b)
{
	long long n;
	while (b != 0)
	{
		n = a % b;
		a = b;
		b = n;
	}
	return a;
}

// 최대 공약수 - 두 수의 곱에 최소 공배수를 나눈 값
long long lcm(long long a, long long b)
{
    return a * b / gcd(a, b);
}

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);
	long long N,K,n,ans;
	cin>>N>>K;
	ans = N;
	vector<int> v;
	for(int i = 0;i<K;i++)
	{
		cin>>n;
		v.push_back(n);
	}
    // kCn으로 조합을 구한다.
	for(int n = 1; n<=K; n++)
	{
		vector<int> c(K,0);
		for(int i = 0;i<n;i++)
			c[i] = 1;
		do{
			vector<int> selected;
			for(int i = 0;i<K;i++)
			{
				if(c[i]==1)
					selected.push_back(v[i]);
			}
			long long sum = selected[0];
			for(int i = 1;i<selected.size(); i++)
				sum = selected[i]<sum ? lcm(selected[i],sum) : lcm(sum,selected[i]);
            // 조합의 n이 짝수인 경우 더해주고 홀수인 경우 빼준다.
			ans += n%2==0 ? N/sum : -1*N/sum;
		}while(prev_permutation(c.begin(),c.end()));
	}
	cout<<ans;
	return 0;
}