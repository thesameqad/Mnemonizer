# Introduction
Mnemonizer is the new way to remember everything. 
This implementation represents 2 mnemonic algorythms and a WCF service, that allows any company to integrate mnemonic logic into their application.   
# What is mnemonization?
Mnemonization is a process of any string tranformation into the sentence, that makes sence to a human.
Demnemonization should always return the origin string.
# What is the purpose of mnemonization?
How many times you called to the bank or insurance company from a cell phone and spell your last name or email? 
You are lucky if your last name is well known or short. Mine is "Yermolayev" and 
I you can imagine how long it takes me to tell the correct spelling. 
Wouldn't it be better, if I will tell some meaningful sentence, like "Big red elephant" instead?
If the person I am talking to has some tool that could translate "Big red elephant" into "Yermolayev", that would save both of us a lot of time. 
That's exactly what my algorythm does. At this point, I am just providing an open source algorythm, but not a consumer product, so, 
if you would find it useful, I can't wait to see, what product can you build on top of it.
#How to use this code?
Code usage is as simple as I can imagine. If you want to menmonize a string, simply write:
```csharp
string input = "Yermolayev";
var coder = new MnemonicCoder();
string mnemonicString = coder.GetMnemonicString(input);
```
If you want to do the opposite, simply write:
```csharp
var coder = new MnemonicCoder();
coder.GetOriginalString(enterString);
```
Both algorythms are developed on .NET, so, if you want to use it in different language, you can use the Restfull API like in the Javascript sample below::
```javascript
var serviceUrl = "THE URL TO HOST ServiceJson.svc";
    function getOriginalString(input) {
        url = serviceUrl + "/GetOriginal/" + input;
        $.getJSON(url, null,
            function (data) {
                  if(console && console.log){
                    if (data == null) {
                      console.log("Unexpected exception was thrown");
                    }
                    else {
                      console.log("Result is :"+data.resultString);
                    }
                  }
            }
         );
     }
     function getMnemonicString(input) {
            url = serviceUrl + "/GetMnemonic/" + input;
            $.getJSON(url, null,
               function (data) {
                  if(console && console.log){
                    if (data == null) {
                      console.log("Unexpected exception was thrown");
                    }
                    else {
                      console.log("Result is :"+data.resultString);
                    }
                  }
               }
            );
        }
```
