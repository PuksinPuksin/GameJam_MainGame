# Unity SoundManager
2D 용 사운드 매니저입니다.
## 사용법
### 설명
사운드의 종류를 구분하여 각각 Resources\Sound\Fx , Resources\Sound\BGM 폴더안에 넣어놔야함

### BGM
한번 틀면 루프상태. 
### Fx
끝나면 꺼집니다.

### BGM 틀기
```c#
SoundManager.Instance.PlayBGMSound("BGMSample");
```
### Fx 틀기
```c#
SoundManager.Instance.PlayFXSound("FxSample");
```

