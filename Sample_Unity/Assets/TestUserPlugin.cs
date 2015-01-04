using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices;
using System;
namespace anysdk {
	public class TestUserPlugin : MonoBehaviour {

		void Awake()
		{

		}

		void Start()
		{


			AnySDKUser.getInstance () .setListener (this,"UserExternalCall");
		}

		void UserExternalCall(string msg)
		{
			Debug.Log("UserExternalCall("+ msg+")");
			Dictionary<string,string> dic = AnySDKUtil.stringToDictionary (msg);
			int code = Convert.ToInt32(dic["code"]);
			string result = dic["msg"];
			switch(code)
			{
			case (int)UserActionResultCode.kInitSuccess://初始化SDK成功回调
				break;
			case (int)UserActionResultCode.kInitFail://初始化SDK失败回调
				break;
			case (int)UserActionResultCode.kLoginSuccess://登陆成功回调
				break;
			case (int)UserActionResultCode.kLoginNetworkError://登陆失败回调
			case (int)UserActionResultCode.kLoginCancel://登陆取消回调
			case (int)UserActionResultCode.kLoginFail://登陆失败回调
				break;
			case (int)UserActionResultCode.kLogoutSuccess://登出成功回调
				break;
			case (int)UserActionResultCode.kLogoutFail://登出失败回调
				break;
			case (int)UserActionResultCode.kPlatformEnter://平台中心进入回调
				break;
			case (int)UserActionResultCode.kPlatformBack://平台中心退出回调
				break;
			case (int)UserActionResultCode.kPausePage://暂停界面回调
				break;
			case (int)UserActionResultCode.kExitPage://退出游戏回调
				break;
			case (int)UserActionResultCode.kAntiAddictionQuery://防沉迷查询回调
				break;
			case (int)UserActionResultCode.kRealNameRegister://实名注册回调
				break;
			case (int)UserActionResultCode.kAccountSwitchSuccess://切换账号成功回调
				break;
			case (int)UserActionResultCode.kAccountSwitchFail://切换账号成功回调
				break;
			case (int)UserActionResultCode.kOpenShop://应用汇  悬浮窗点击粮饷按钮回调
				break;
			default:
				break;
			}
		}
		
		void OnDestroy() {
			
		}
		
		void OnGUI()
		{	GUI.color = Color.white;

			GUI.skin.button.fontSize = 30;
			if(GUI.Button(new Rect(5, 5, Screen.width - 10, 70),"Login" ))
			{

				login();
			}
			int i = 1;
			if (AnySDKUser.getInstance ().isFunctionSupported ("logout")) {
						if (GUI.Button (new Rect (5, 75 * i + 5 , Screen.width - 10, 70), "logout")) {
								logout ();
						}
				i++;
				}
			if (AnySDKUser.getInstance ().isFunctionSupported ("enterPlatform")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "enterPlatform")) {
								enterPlatform ();

						}
				i++;
				}

			if (AnySDKUser.getInstance ().isFunctionSupported ("showToolBar")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "showToolBar")) {
				
								showToolBar (ToolBarPlace.kToolBarBottomLeft);
						}
				i++;
				}
			
			if (AnySDKUser.getInstance ().isFunctionSupported ("hideToolBar")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "hideToolBar")) {
				
								hideToolBar ();
						}
				i++;
				}
			
			if (AnySDKUser.getInstance ().isFunctionSupported ("accountSwitch")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "accountSwitch")) {
				
								accountSwitch ();
						}
				i++;
				}

			if (AnySDKUser.getInstance ().isFunctionSupported ("antiAddictionQuery")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "antiAddictionQuery")) {
								antiAddictionQuery ();
						}
				i++;
				}
			if (AnySDKUser.getInstance ().isFunctionSupported ("realNameRegister")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "realNameRegister")) {
								realNameRegister ();
						}
				i++;
				}

			if (AnySDKUser.getInstance ().isFunctionSupported ("submitLoginGameRole")) {
				if (GUI.Button (new Rect (5, 75 * i + 5, Screen.width - 10, 70), "submitLoginGameRole")) {
								submitLoginGameRole ();
						}
				i++;
				}

			if(GUI.Button(new Rect(5, 75 * i + 5, Screen.width - 10, 70),"return" ))
			{
				Destroy (GetComponent ("TestUserPlugin" ));
				this.gameObject.AddComponent("Test");
			}


		}
		
			// Update is called once per frame
		void Update() {
			if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Home))  
		    {  
				Application.Quit(); 
				AnySDK.getInstance ().release ();
		    } 
		}
	
		
		/**
		 * 登录
		 */
		void login() {
			AnySDKUser.getInstance ().login();
		}
		
		/**
		 * 注销
		 */
		void logout() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "logout" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "logout" );
			}
		}
		
		/**
		 * 进入平台
		 */
		void enterPlatform() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "enterPlatform" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "enterPlatform" );
			}
		}
		
		/**
		 * 显示Toolbar
		 */
		void showToolBar(ToolBarPlace align ) {
			if( AnySDKUser.getInstance ().isFunctionSupported( "showToolBar" ) ) {
				AnySDKParam param = new AnySDKParam((int)align);
				AnySDKUser.getInstance ().callFuncWithParam( "showToolBar", param );
			}
		}
		
		/**
		 * 隐藏Toolbar
		 */
		void hideToolBar() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "hideToolBar" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "hideToolBar" );
			}
		}
		
		/**
		 * 切换账号
		 */
		void accountSwitch() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "accountSwitch" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "accountSwitch" );
			}
		}
		
		/**
		 * 防沉迷查询
		 */
		void antiAddictionQuery() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "antiAddictionQuery" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "antiAddictionQuery" );
			}	
		}
		
		/**
		 * 实名注册
		 */
		void realNameRegister() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "realNameRegister" ) ) {
				AnySDKUser.getInstance ().callFuncWithParam( "realNameRegister" );
			}	
		}
	
		/**
		 * 把游戏数据传递到SDK服务端
		 */
		void submitLoginGameRole() {
			if( AnySDKUser.getInstance ().isFunctionSupported( "submitLoginGameRole" ) ) {
				Dictionary<string, string> userInfo = new Dictionary<string, string>();
				userInfo["roleId"] = "123456";
				userInfo["roleName"] = "test";
				userInfo["roleLevel"] = "10";
				userInfo["zoneId"] = "123";
				userInfo["zoneName"] = "test";
                userInfo["dataType"] = "1";
                userInfo["ext"] = "login";
				AnySDKParam param = new AnySDKParam(userInfo);
				AnySDKUser.getInstance ().callFuncWithParam( "submitLoginGameRole", param );
			}	
		}
	}
}
