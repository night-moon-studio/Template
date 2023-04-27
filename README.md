
## 欢迎使用 Night Moon Studio 的开源模板.

> 所有细微的配置请参考工程中的 [[使用说明.txt](https://github.com/night-moon-studio/Template/blob/main/%E4%BD%BF%E7%94%A8%E8%AF%B4%E6%98%8E.txt)] 文档。


## 文章导航

- [模板介绍](https://www.cnblogs.com/NMSLanX/p/17326728.html)
- [项目及脚本介绍](https://www.cnblogs.com/NMSLanX/p/17328697.html)
- [ISSUE 相关](https://www.cnblogs.com/NMSLanX/p/17328924.html)
- [PR 相关](https://www.cnblogs.com/NMSLanX/p/17328962.html)
- [发布相关](https://www.cnblogs.com/NMSLanX/p/17329521.html)
- 从0到发布(编写中)


## 了解这款开源模板:

- 模板目录结构清晰,允许 .NET 开源爱好者直接上手免费开发:
	- 单元测试: /test/ut/ 为存放单元测试工程的文件夹. 
	- 性能测试: /test/benchmark/ 为存放性能测试工程的文件夹.
	- 样例文件夹: /samples/ 存放源码样例的文件夹.
	- 源码文件夹: /src/ 存放源码工程的文件夹.


- 实战配置:
	- 工程配置及管道配置吸取了大量的实战配置,满足大多数 .NET 开源开发者.
	- 有详细的 [使用说明.txt] 教程指导开发者理解和完成配置.


- 一些疑问:
	- 工程中为何没有文档网站搭建相关的内容?(答:暂时没有,建议文档与工程分开.)
	- 我是否可以魔改这个模板?(答:可以,但更改目录结构可能破坏管道的一些功能，首先需要了解管道功能才可根据自己的需求定制模板.)


## 管道说明

### 关键 Token 配置:

- Apply Token(可创建永久的):
  
    - 如果您的工程存放在个人账户下, 您需要申请一个私人 [Token](https://docs.github.com/zh/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) 来开放权限使用管道:
    - 请创建 经典版(classic) Token 而不是 Fine-grained Token, 后者权限太低;
    - 复制生成好的 Token 字符串, 在你的项目 Setting -> Secrets and variables -> Action 中创建变量: 

| 环境变量 | 值 |
| :------: | :--: |
| REPO_GITHUB_TOKEN | {{your token string}} |


### ISSUE 管道:

- ISSUE 推荐:
    - 当一个 ISSUE 创建时，我们的推荐功能将发挥作用，挑选出最多 7 个与其相似的 ISSUE.


- ISSUE 用户屏蔽:
    - 当您收到一些恶意的无用的令人困扰的 ISSUE 时，您只需为其添加一个 aaa-block-user 标签，即可在该库中屏蔽该发帖用户。


### PR 管道:

- PR 检测 管道:
    
    - 单元测试:
  
        - 该管道将在用户向 dev** 提交 PR 后自动触发.
        - 该管道执行三个平台的 UT 测试任务.
        - 用户需要注意提交上来的代码是否有绕过 UT 测试.

    - 标签标记:

        - Label 标记将根据 labeler.yml 的配置对 PR 提交的代码进行标记.
      
    - ISSUE关联:

        - PR 标题将和指定的 ISSUE 进行比对，挑选出合适相似度的 ISSUE 进行关联.

  
- PR 合并 管道:
  
    - 该管道将在成功合并 PR 后触发.
    - 该管道将当前 PR 添加到 {Project_Name}_VNext 的计划中.
    - 如果不存在 VNext 计划,将自动创建, 并归档当前 PR.
    - {Project_Name}_VNext 将在发版时自动归档.

### 发布管道:

	发布管道将并行运行3个任务, 3个任务彼此之间互不影响, 如果其中执行出现意外, 可重复触发.

- 打包任务:
  
    - 将在 CHANGELOG.md 提交时自动触发.
    - 将扫描 CHANGELOG.md 最后一个版本信息.
    - 将执行 ubuntu 环境的 UT 测试.
        - 1 是保证发布之前 UT 测试是通过的.
        - 2 是生成代码覆盖率文件.
    - 如果用户配置了代码覆盖率的上传密钥(https://app.codecov.io/gh/{{user}}/{{project}}/settings),覆盖率文件将上传至[网站](https://app.codecov.io/gh).
    - 然后执行 public 测试, 测试将匹配 CHANGELOG.md 以及 NUGET 网站中的包信息, 如果工程的打包信息合法,则进行打包.
    - 如果用户配置了 NUGET 的上传密钥,覆盖率文件将上传至 NUGET.

- Release 任务:
  
    - 将在 CHANGELOG.md 提交时自动触发.
    - 扫描 CHANGELOG.md 最后一个版本信息.
    - 如果不存在该版本信息的包,将自动以该版本信息发布 Release / Tag 包.

- Project 归档任务:
  
    - 将在 CHANGELOG.md 提交时自动触发.
    - 扫描 CHANGELOG.md 最后一个版本信息.
    - 归档现有的 {{project}}_VNext 计划到 {{project}}_Release_v{{version}} 计划.
    - 创建新的 {{project}}_VNext 计划.

> 发布管道不一定都执行成功,如 NUGET 上已存在发布包, 则 NUGET 任务在二次触发时将执行失败.


## 其他功能

这款模板除了实用的管道外还有其他功能：

1. ISSUE 提问模板，您可以提一个 ISSUE 看看样例;

2. 依赖检测机器人

    - 可以查看 project.yml 查看每个项目的依赖配置.