---
name: VTCodeTemplate Generate
description: 需要使用 VTCodeTemplate 插件来生成代码模板文件和填充代码时，按下面的说明和流程来执行
---

## 生成限定
    只能生成C#模板代码文件。
    模板填充代码也是C#文件。

## VTCodeTemplate 说明
    说明文件可以参考 reference/Document_ZH.pdf
    reference/examples 里存放的是示例文件。可以用来参考，都是C# 代码模板
    下面是对 vtemplate 的说明

### Template 文件
    文件格式为 *.vtemplate。其中定义了基本的代码结构和模板区域
    
### VTemplate模板语法
#### 普通文本替换语句
    语法格式：
```
    $Tag$
```
    语法说明：
        1.Tag是自定的可以用来填充文本的符号
    示例：
```
    $TextContent$
```

#### 循环语句
    语法格式:
```
    $Repeat AreaTag$
    .....
    $EndRepeat$
```
    语法说明：
        1. AreaTag用来标识该循环区域
        2. $Repeat xxx$是循环区域的开始
        3. $EndRepeat$是循环区域的结束
        4. 区域中可以是任何文本，也可以带VTemplate定义的模板语句

    示例：
```
    $Repeat LoopArea$
    Console.WriteLine("Hello World");
    $EndRepeat$
```

#### 条件控制语句
    语法格式:
```
    $If AreaTag$
    .....
    $EndIf$
```
    语法说明：
    1. $If AreaTag$
    2. $If xxx$是条件控制区域的开始
    3. $EndIf$是条件控制区域的结束
    示例：
```
    $If ConditionToggle$
    Console.WriteLine("Condition Area");
    $EndIf$
```

#### 子区域语句
    语法格式:
```
    $SubArea UniqueAreaTag$
    .....
    $EndSubArea$
```
    语法说明：
    1.  $SubArea UniqueAreaTag$表示子区域语句的开始
    2.  $EndSubArea$表示子区域的结束
    3.  子区域中可以编写任意文本，包括代码文本和模板文本。
    示例：
```
    $SubArea UniqueArea$
    Console.WriteLine("Sub Area");
    $EndSubArea$
```
#### 包含语句
    语法格式：
```
    $Include "OtherTmpl.vtemplate"$
```
    语法说明：
    1. $Include "vtemplate file path"$表明要打开一个vtemplate，并放置在这一行。
    示例：
```
    $Include "Item.vtemplate"$
```

## VTCodeTemplate 插件使用说明

### 创建TemplateHandler
```
    TemplateHandler templateHandler = new TemplateHandler("Path/To/VTemplate/File/Path");
```
### 数据上下文
    数据上下文用来填充模板标记替换数据
#### 全局数据上下文
    获取示例：
```
IDataContext globalDataContext = templateHandler.GlobalDataContext;
```
#### 循环区域数据上下文
    获取示例：
```
IRepeatDataContext repeatDataContext = templateHandler.GetRepeatDataContext("LoopAreaTag");
```

##### 为循环区域创建数据上下文
    示例代码
```
IRepeatDataContext repeatDataContext = templateHandler.GetRepeatDataContext("LoopAreaTag");
for(int i = 0; i < 10; i++)
{
    IDataContext currentDataContext = 
    repeatDataContext.CreateNextIteratorDataContext();
    currentDataContext.AddReplaceValue("Count", (i + 1).ToString());
}
```

#### 子区域数据上下文
    获取示例：
```
IDataContext subAreaDataContext = tempalteHandler.GetSubAreaDataContext("SubAreaTag");
```

#### 设置条件状态
    代码示例:
```
tempalteHandler.SetConditionActive("ConditionTag", true);
```

### 数据上下文接口
#### IDataContext
```
public interface IDataContext
{
    string[] ReplaceTags { get; }
    void AddReplaceValue(string tag, string value);
    string GetReplaceValue(string tag);
}
```
* ReplaceTas
    * 获取所有上下文中的标记
* AddReplaceValue
    * 设置标记对应的值，参数tag是要替换的模板标记，value是要替换的值
* GetReplaceValue
    * 获取特定标记对应的值

#### IRepeatDataContext
```
public interface IRepeatDataContext
{
    IDataContext CreateNextIteratorDataContext();
    IDataContext[] DataContexts { get; }
    IDataContext GetDataContext(int index);
}
```

* CreateNextIteratorDataContext
    * 创建一轮迭代的数据上下文，返回值为本次迭代的数据上下文IDataContext
* DataContexts
    * 获取所有已经创建的数据上下文数组
* GetDataContext
    * 获取索引对应的数据上下文

### 编译生成代码文件
    示例：
```
templateHandler.Compile("Path/To/Target/CSharp/File/Path");
```

## 注意事项
1. 代码注释中，不能出现任何模板标记
2. 模板语法中不应该出现括号：{}

