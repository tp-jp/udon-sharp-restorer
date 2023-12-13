# UdonSharpRestorer

UdonSharpBehaviourの設定値を復元するツール。  
VRChatのワールド作成時などにご利用ください。

## 導入方法

VCCをインストール済みの場合、以下の**どちらか一つ**の手順を行うことでインポートできます。

- [VCC Listing](https://tp-jp.github.io/vpm-repos/) へアクセスし、「Add to VCC」をクリック

- VCCのウィンドウで `Setting - Packages - Add Repository` の順に開き、 `https://tp-jp.github.io/vpm-repos/index.json` を追加

[VPM CLI](https://vcc.docs.vrchat.com/vpm/cli/) を使用してインストールする場合、コマンドラインを開き以下のコマンドを入力してください。

```
vpm add repo https://tp-jp.github.io/vpm-repos/index.json
```

VCCから任意のプロジェクトを選択し、「Manage Project」から「Manage Packages」を開きます。
一覧の中から `UdonSharpRestorer` の右にある「＋」ボタンをクリックするか「Installed Vection」から任意のバージョンを選択することで、プロジェクトにインポートします。 
![image](https://github.com/tp-jp/udon-sharp-restorer/assets/130125691/c3761fd2-1f76-4353-9723-0c4605ccff39)

リポジトリを使わずに導入したい場合は [releases](https://github.com/tp-jp/udon-sharp-restorer/releases) から unitypackage をダウンロードして、プロジェクトにインポートしてください。

## 使い方

UnityProjectを開いた際に自動で復元処理が実行されるため、手動で実行する必要はありません。

## 更新履歴

[CHANGELOG](CHANGELOG.md)
