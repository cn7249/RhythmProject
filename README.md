# 리듬프로젝트(가제)
Unity 게임 개발 심화 주차 3조(개발은 삼순이발) 팀 과제
## 프로젝트 소개
리듬의 매력을 노래와 함께 느낄 수 있는 리듬게임
### 개발 기간
- 24/02/26 ~ 24/03/05

### 참여인원 밑 역할
|팀원|역할|깃헙 링크|
|------|---|---|
|강성원(팀장)|랭킹 시스템 제작|https://github.com/ChocoMucho |
|금경희|곡 선택 등 메뉴 제작|https://github.com/masterkeum |
|추민규|채보 툴 제작|https://github.com/cn7249 |
|최철환|인게임 제작|https://github.com/sskesu |


## 주요 기능
### 채보 툴
<details>
<summary>패턴 시퀀서(일명 채보툴)</summary>
<div markdown="1">

![image](https://github.com/cn7249/RhythmProject/assets/49467508/ab1f351f-0b58-4684-bfc0-f452a4e5ae2d)


BarBehaviour.cs - 채보툴에서 마디를 클릭했을 때의 반응 등의 UI 행동

GridBtnBehaviour.cs - 클릭한 위치에 노트가 생성되고 각 트랙의 List에 해당 정보가 변환되게 행동

NotePSBehaviour.cs - 생성한 노트의 마우스 우클릭 시 삭제

비트 셀렉터UI.cs - 4, 8, 12, 16박자 선택 UI와 제어

그리드 정보UI.cs - 패턴 그리드의 마디 선택과 확대/축소 정보 제공 UI의 제어

SaveLoadUI.cs - 채보 파일(.xml)의 저장과 불러오기 UI의 제어

GridController.cs - 패턴 그리드의 이동 관련 스크립트

InputPreset.cs - 박자별 프리셋 생성기, 24, 32박 등 원하는 박자의 프리셋이 필요하다면 사용

PatternManager.cs - 싱글톤, 채보툴의 중추적인 역할을 담당

XMLManager.cs - XML 파일의 저장과 불러오기를 담당

</div>
</details>


### 인게임(리듬게임 메인)

<details>
<summary> 인게임 UI & 이펙트(인게임 UI 와 효과)</summary>
<div 마크다운="1">
 
![image](https://github.com/cn7249/RhythmProject/assets/49467508/4b27d1a1-43dc-4514-8890-70a6d7620f4b)

GearInput.cs - (입력 프로토타입, 나중에 철환님께서 마무리)

NoteGenerator.cs - 만들어놓은 채보 파일(.xml 확장자)을 불러와 노트로 만듦

NoteGenerator.cs - 만들어놓은 채보 파일(.xml 확장자)을 불러와 노트로 만듦

UI_ComboFX.cs - 콤보 UI의 조건과 애니메이션 제어

UI_ComboFX.cs - 콤보 UI의 조건과 애니메이션 제어

UI_JudgeEffects.cs - 판정 UI의 조건과 애니메이션 제어

UI_JudgeEffects.cs - 판정 UI의 조건과 애니메이션 제어

</div>
</details>


### 랭킹 시스템
<details>
<summary> 곡 별로 랭킹 출력 </summary>
<div 마크다운="1">
곡 별로 랭킹이 출력됩니다.

랭킹의 정렬은 병합 정렬을 사용하여 중복 요소에 대한 불안정성을 없앴습니다.

![image](https://github.com/cn7249/RhythmProject/assets/49467508/6a2e4735-bdda-464f-b057-d199e48d1429)


</div>
</details>

### 곡 리스트
<details>
<summary> 곡의 리스트 출력</summary>
<div 마크다운="1">
 
![image](https://github.com/cn7249/RhythmProject/assets/49467508/7fb22ecd-9eeb-4293-9f53-1453e5d55bce)
 
ui 기능에서는 플레이 음악을 누르면 음악이 재생되고 다시한번 누르면 플레이를 할 수 있는 구조입니다.

해당기능에서 음악을 플레이 하고 다른곡을 누르면 멈추고 플레이 하게 제작했습니다.
</div>
</details>


