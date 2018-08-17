# Select

Select는 데이터를 검색하는 명령이다. 기본적으로 데이터를 조화하는 실행을 한다. Select에서 데이터를 변경할 수 없으며 읽기만 가능하다.

## Example

```sql
select * from school where name='wonho'
//학교에서 이름이 원호인 행을 출력
```

```sql
select age from school where name='wonho' and class = 2
//학교에서 이름이 원호이며 반이 2인 원호의 이름을 출력
```


```sql
select max(age) from school where class = 2
//학교에서 반이 2인 사람들의 최대나이를 출력
```

```sql
select sum(age) from school where class = 2
//학교에서 반이 2인 사람들의 나이의 합을 출력
```

```sql
작성 순서
select / from / where / group by / having / order by
```
## Functions

Select에서 같이 사용이 가능한 유용한 몇가지 함수를 소개하고자한다. 표준이 아닌 함수의 경우 따로 표기를 하겠다.

### Summary

데이터를 계산하여 요약해준다. 프로그램에서 처리하는 계산이 줄어든다.

- max<br/>가장 큰 수를 표시하는 함수.
- min<br/>가장 작은 수를 표시하는 함수.
- avg<br/>평균을 계산하여 표시하는 함수
- sum<br/>모든 합을 표시하는 함수.
- count<br/>Null을 포함하여 갯수를 표시하는 함수.
<br/>
- GROUP_CONCAT<br/>비표준 함수. (오라클LISTAGG/postgre STRING_AGG...) 문자열을 다 합쳐준다. 만약, 중복을 피하고 싶다면 group_concat(DISTINCT target)와 같이 사용한다.

### Ordering

여러 기능중에서 정렬은 한번쯤 쓸만 하다. 가장 작거나 큰 데이터를 파악할 때에는 유용한 방법이다.
정렬하는데 쓰이는 값의 종류를 '정렬키'라고 한다.

```sql
select * from school where class = 2 order by name desc
//학교에서 2반인 사람을 이름이 뒤인 순서대로 보여준다.
```

```sql
select * from school where class = 2 order by age desc,name desc
//학교에서 2반인 사람을 나이와 이름이 뒤인 순서대로 보여준다.
```

### Grouping

데이터를 분석할 때, 데이터의 속성을 파악하지 못한다면 분석하기 힘들다. 데이터를 그룹을 지어 더 좋은 데이터를 생산할 수 있다.

```sql
select sex, count(*) from school where class = 2 group by sex
//학교에서 2반인 사람중, 성별로 나누어 수를 샌다.
```

```sql
select sex, count(*) from school where grade = 2 group by sex having min(age)=18
//학교에서 2학년 중, 성별로 나우어진 그룹중 나이의 최소가 18인 그룹의 성별과 수를 표시함.
```

