# SampleProject
SimpleDI와 UISystem 프레임워크를 이용해서 만든 간단한 UI 샘플 프로젝트 입니다.

## 실행법
Scenes/Lobby.scene에서 실행하시면 됩니다.

## 아키텍쳐 모델
샘플 프로젝트의 모델은 다음과 같은 구조를 가진 MVVM 모델을 쓰고 있습니다.   
여기서는 Model이라는 명칭 대신 Manager로 사용하고 있습니다.   

<div style="float: right;">
<img width="847" alt="스크린샷 2020-04-06 오후 10 31 58" src="https://user-images.githubusercontent.com/62090142/78563784-7a253200-7856-11ea-8d73-4663aad1c04f.png">
</div>

View: 유니티 게임오브젝트 계층으로 사용자에게 보여지고 Input이벤트를 얻어오는 역할을 합니다. View는 ViewModel을 통해서 데이터를 얻어 옵니다.   
ViewModel: Manager와 Model 계층을 View로부터 분리는 역할을 합니다. 일반적인 ViewModel과는 다르게 비지니스 로직을 가지고 있지 않고, 오직 View와 Manager간의 중재자 역할만을 수행합니다.   
Manager: 실제 게임내에 이용되는 비지니스 로직과 데이터를 캡슐화한 계층 입니다.   

이 아키텍처를 통해 코어 로직과 게임 오브젝트를 분리함으로써 유지보수를 향상 시킬 수 있습니다.   

그리고 현재 프로젝트는 매우 단순하기에 추가하지 않았지만, 만약 프로젝트의 사이즈가 커질 경우, Manager 파트를 데이터 바인딩을 담당하는 Model로 분리시켜, MVVM + Service(Manager) 아키텍처로 확장할수 있는 여지 또한 존재합니다.   

<div style="float: right;">
<img width="842" alt="스크린샷 2020-04-06 오후 10 31 42" src="https://user-images.githubusercontent.com/62090142/78563776-785b6e80-7856-11ea-9fbe-d9d8b6be90dc.png">
</div>

MVVM + Service 아키텍처의 경우,   
Model은 UI의 Data-Binding값을 저장하고   
Manager는 이전 구조 그대로 비지니스 로직과 데이터를 분리합니다.   

## Main Scene의 UI 노드 구조
Lobby Scene은 Lobby 스크린 하나이기에 따로 노드 구조가 없지만,   
Main Scene의 UI는 Main, User, Settings Screen으로 나눠져있어 간단한 노드구조로 구성되어 있습니다.

<div style="float: right;">
<img width="400" alt="스크린샷 2020-04-04 오후 11 57 16" src="https://user-images.githubusercontent.com/62090142/78454150-39e87700-76d1-11ea-808e-5e30f05f3e72.png">
</div>

## 관련 Repository
SimpleDI: https://github.com/SheepBros/SimpleDI   

UISystem: https://github.com/SheepBros/UISystem   

## Unity 버전
이 프로젝트는 2018.4.20f1(LTS) 버전에 맞게 수정되었습니다.
