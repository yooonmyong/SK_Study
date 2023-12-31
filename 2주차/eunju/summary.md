## 벡터

2장에서 수를 사용하여 수직선에서 수를 나타내고 **연산을 통해 움직임을 표현**했다. 이를 평면에서도 표현하고자 벡터를 사용한다.

- 벡터란? - 평면을 구성하는 원소

### 데카르트 좌표계

데카르트 좌표계의 한 원소는 곱잡합과 동일하게 순서쌍으로 표현하며 좌표라고 부른다.

이러한 좌표는 **크기와 방향** 두가지 속성을 가진다.

- **평면에서의 움직임을 나타내기 위한 연산이 필요하다.**

## 벡터 공간과 벡터

벡터 공간의 좌표는 주 실수 (x,y)로 이루어져 있기 때문에 **좌표의 연산은 실수가 지니는 체의 구조를 바탕으로 설계되어 있다.**

- **벡터공간이란?**
    - 두 개 이상의 실수를 곱집합(ex. (x,y),(x,y,z))으로 묶어 형성된 집합을 공리적 집합론 관점에서 규정한 것
    

### 스칼라와 벡터

- **스칼라**
    - 하나의 숫자로만 표시되는 양 즉, **단지 크기만 있는 물리량**이다. 벡터, 텐서 등이 방향과 크기가 있는 물리량인데 대하여 방향의 구별이 없는 수량
- **벡터**
    - 체 집합을 가지는 수 집합의 원소, 벡터 공간에서의 원소를 의미함

### 벡터 공간의 연산

1. **벡터와 벡터의 덧셈**

체의 구조가 가지는 연산의 성질은 모두 체의 공리를 기반으로 하기 때문에 헤당되는 연산의 공리가 참입을 입증하지 않아도 된다.

- 벡터의 합의 교환법칙과 두 스칼라의 덧셈의 교환 법칙
    - x1,y1,x2,y2는 스칼라고 모두 체 집합의 원소이다.
    - v1+v2 = (x1,y1)+(x2,y2) = (x1,x2) + (y1,y2)
    - v2+v1 = (x2,y2)+(x1,y1) = (x2,x1) + (y2,y1)
        
        **∴** v1+v2 = v2+v1 
        
- 벡터의 합의 교환법칙과 두 스칼라의 덧셈의 교환 법칙 시각적으로 확인하기
    - 평면의 점을 각 축에 대해 독립적으로 평행이동시키는 작업으로 해석이 가능하다.
        
![IMG_D5A0A286A95A-1 (1)](https://github.com/encrypted-def/basic-algo-lecture/assets/46295539/f77ab3e9-cad4-4a0f-87d8-cf6115bf6606)


1. **스칼라와 벡터의 곱셉**

스칼라 곱셉의 결과는 항상 원점을 지나는 직선상의 벡터를 만들어낸다.

**프로그래밍에서 스칼라와 벡터 곱**

 벡터와 스칼라 연산은 스칼라부터 모두 계산한 뒤에, 벡터와 계산하는 것이 성능 상 좋다.

```csharp
// Bad
Vector3 vec2 = vec * a * b;
// Vector3 temp = new Vector3(vec.x  * a, vec.y  * a, vec.z  * a);
// Vector3 vec2 = new Vector3(temp.x * b, temp.y * b, temp.z * b);

// Good
Vector3 vec2 = a * b * vec;
```

🔗 reference : [https://rito15.github.io/posts/unity-opt-script-optimization/#벡터-연산-시-주의사항](https://rito15.github.io/posts/unity-opt-script-optimization/#%EB%B2%A1%ED%84%B0-%EC%97%B0%EC%82%B0-%EC%8B%9C-%EC%A3%BC%EC%9D%98%EC%82%AC%ED%95%AD)

### 벡터의 크기와 이동

벡터의 크기는 피타고라스 정리를 사용하여 계산하고 절댓값 기호를 사용하여 표시한다.

- **단위 벡터 (Unit Vecter)**
    - 단위 벡터인 경우 hat 기호를 사용하여 표기한다.
    - 임의의 벡터를 크기가 1인 단위 벡터로 다듬는 과정을 정규화라고 한다.

> **In Unity**
> 

> 어떤 벡터를 자신의 크기로 나누면 그 결과는 크기가 1인 벡터가 되며, 이 벡터를 노멀라이즈 벡터라 합니다. 노멀라이즈 벡터에 스칼라를 곱하면 결과 벡터의 크기는 해당 스칼라 값과 같아집니다. 힘의 방향은 일정하지만 강도를 제어할 수 있는 경우에 유용합니다(예: 자동차 바퀴의 힘은 항상 앞 방향으로 차를 움직이지만 그 동력은 운전자가 제어합니다).
> 

🔗 reference : https://docs.unity3d.com/kr/530/Manual/UnderstandingVectorArithmetic.html

### 벡터의 결합과 생성

- **선형 결합** **[(linear combination)](https://er5030000.tistory.com/entry/%EB%B2%A1%ED%84%B0-%EC%84%A0%ED%98%95-%EA%B2%B0%ED%95%A9)**
    - n개의 스칼라와 n개의 벡터를 결합해 새로운 벡터를 생성하는 수식
    - 두 벡터를 스케일하고 더해 새로운 벡터를 생성하는 모든 연산은 두 벡터의 선형 결합이다.
- 벡터를 선형관점에서 바라보기
    - (1,0) 과 (0,1)의 스케일된 두 벡터의 합
    <img width="456" alt="Untitled (1)" src="https://github.com/slew61/MindCareApp/assets/46295539/0e1e744c-f855-4239-b296-89ee4c3ec1bc">
🔗 https://youtu.be/2CcCOgDilO8?si=t6SAzMRn-Qh6-IE9
    
- **선형 종속의 관계**
    - 모든 a가 0이 아님에도 영벡터를 만들 수 있다면 선형 결합에 사용된 벡터는 서로 선형 종속의 관계를 가진다고 표현한다.
    
    → **평행한 두 벡터를 결합한 결과는 두개의 벡터의 결합이 아닌 하나의 벡터에 스칼라 곱을 적용한 결과에 불과하다.**
    
- **선형 독립의 관계**
    - 모든 a가 0이여야 영벡터를 만들 수 있다면 선형 결합에 사용된 벡터는 서로 선형 독립의 관계를 가진다고 표현한다.
    
    **→ 선형 독립의 관계를 가지는 벡터를 선형 결합하면 백터 공간에 속한 모든 벡터를 생성할 수 있다.**
    
    **→ 선형 독립의 관계가 유지되려면 2개의 벡터만 사용되어야한다.**
    

### 기저 (base)

- 벡터 공간 내 **모든 벡터를 생성할 수 있는 선형 독립 관계를 가지는 벡터의 집합**을 기저라고 한다.
- **기저 벡터**
    - 집합의 개념인 기저에 속한 원소를 기저 벡터라고 한다.
    - **다른 기저 벡터를 선택할 수 있다.**
        - 새로운 좌표계를 얻을 수 있으며 이것을 통해 선형 변환을 진행한다.
     
