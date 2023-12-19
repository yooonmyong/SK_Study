// 백준 jyunni님 코드
// 코드 풀이 참고: https://kau-algorithm.tistory.com/36

var s=Array.ConvertAll(Console.ReadLine().Split(),long.Parse);

long ExtU(long n,long b)
{
  long r1=n,r2=b,t1=0,t2=1;
  for(long q,r,t;r2>0;){
    q=r1/r2;
    r=r1-q*r2;
    r1=r2;r2=r;
    t=t1-q*t2;
    t1=t2;t2=t;
  }
  if(r1!=1) return -1;
  if(t1<0)t1=n+t1;
  return t1;
}
Console.Write("{0} {1}",s[0]-s[1],ExtU(s[0],s[1]));
