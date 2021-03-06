# PyCon2018
2018 파이콘 발표자료와 소스입니다.

## FP란?
functional programming이란 객체지향과 대조되는 새로운 프로그래밍 패러다임으로 여러 분야에허 활용되고 있습니다. spark는 대표적인 FP의 적용 사례입니다. 병렬프로그래밍, 반응형 프로그래밍에 사용되며 일반적인 상황에서도 언제나 접목가능합니다. FP의 특징은 아래와 같습니다.
- 순수함수

그러나 이 외에도 FP를 편하게 해주는 몇가지 기능이 존재하는데 이는 함수형 패러다임의 지향하는 그 자체는 아니지만 도움을 주며, 밀접하게 연관이 있습니다. 이는 아래와 같습니다.
- 불변자료형
- 모나드
- 고계함수
- 클로저(closure)
- 다형성
- 함수커링

### 순수함수란,
순수함수는 같은 입력에 같은 결과를 반환하는 함수입니다. 수학에서 생각하는 함수와 개념이 완벽이 동일합니다. 사실 우리가 함수라는 용어에 관하여 잘못 사용하는 경우가 있습니다. 다들 잘 아시는 메소드, 프로시저, 함수, 오퍼레이터들은 비슷하지만 다른 역할을 하고 다른 특성을 가집니다. 그런데 저희가 만드는 함수가 과연 같은 입력에 다르게 동작할까요? 그렇습니다. 아래 함수를 한번 보시죠.
```
b = 100
def func(A):
    return A+b
```
이 함수는 순수함수가 아닙니다. 그 이유는 b에 따라 결과가 바뀔 가능성이 있기때문입니다. b가 50이 된다면 A+50이 반환될 것입니다.