
# 业务需求 #
# Business Requirements #

## 订阅 ##
**Subscriptions**

### 等级1 ###

 - 新片（最近30天）：每个月1部
 - 普通片子：每个月1部
 - 每次允许逾期：1
 - 价格：5.99

Level 1:   

- New Releases (last 30 days): 1 a month   
- Standard Release: 1 a month
- Out at any one time: 1
- Price: £5.99

---

### 等级2 ###
 - 新片（最近30天）：每个月2部
 - 普通片子：每个月2部
 - 每次允许逾期：1
 - 价格：7.99

 Level 2:   

- New Releases (last 30 days): 2 a month   
- Standard Release: 2 a month
- Out at any one time: 1
- Price: £7.99

---

### 等级3 ###
 - 新片（最近30天）：无限
 - 普通片子：无限
 - 每次允许逾期：1
 - 价格：9.99

 Level 3:   

- New Releases (last 30 days): Unlimited   
- Standard Release: Unlimited
- Out at any one time: 1
- Price: £9.99

---

### 等级4 ###
 - 新片（最近30天）：无限
 - 普通片子：无限
 - 每次允许逾期：2
 - 价格：11.99

 Level 4:   

- New Releases (last 30 days): Unlimited   
- Standard Release: Unlimited
- Out at any one time: 2
- Price: £11.99

---

## 年龄限制 ##

如果你有专供青少年观看的列表，那么必须严格遵守影片分级制度，只能订阅其相应年龄的影片。

**Age Restrictions**  
If you have lists for younger members they will be restricted to rentals for their age level.

---

## 我如何取消订阅？##
**（抛出停止计费的事件）**

要取消订阅从而退出会员，那么会发生两件事：

 - 你得告诉我们你想退出，这样我们才不会继续把租的dvd发给你。
 - 我们得把所有租给你的dvd都收回来。

 **How can I cancel subscriptions?**  
(throw event to stop billing)  
To cancel your membership with us, two things must happen:  

- You tell us that you want to cancel (so that we stop sending you any more rental discs)
- We receive back all rental discs that you have out on loan 

---

## 升级订阅 ##

因级别降低而减少的租金，将在我们收到dvd后的下一个结算周期生效。反之，因等级提高而增加的租金则立即生效，并按照剩余的结算周期计算。增加的金额将会立即收取，但不会因此修改后续的结算日期。同时，因升级产生的额外费用不可退还。

**Upgrade subscription**   
Any reduction in your bill resulting from a downgrade will take effect at the next billing period after any outstanding discs have been received to us. Any increase in your bill resulting from an upgrade will take effect immediately, being pro-rated to the remainder of your billing period, and the increase will be charged immediately (without changing any subsequent billing dates). Additional charges, resulting from an upgrade, are non-refundable.

---

## 如何降级 ##

在你没有超过限定的dvd数量且已开据发票的情况下，才能在月底进行更改。

注意，你可以在你结算周期内的任何时候改变订阅类型。但你得按期归还dvd，那么才从下一个结算日期开始按新的订阅等级收费。比如本来是3盘的，现在降级为2盘的，那么在收回3张dvd中任何一张之前，我们不会修改你的等级。

**How can I down grade my subscriptions?**  
Only if you don’t have more than your allotted number of discs out. And only after I invoice, i.e. can only change at the end of the month. Note: You can change your plan at any time during your billing month. You will be charged the new price from your next billing date, provided you have returned the correct number of Discs.
For example: if you are on the 3-Disc plan and want to downgrade to a 2-Disc plan, your account will not change until we have received 1 of the 3 Discs you currently possess.

---

## 降级后如何计费？ ##

**（引发更改账单事件）**

你可以在结算周期内任何时候降级。只有当你归还了一定数量dvd后，我们才会从下一个结算日按新的价格收取租金，否则还是按之前的价格收租。在这种情况下，我们建议你暂时保持在较高费用的等级，以获得最佳性价比。之后再在下一个结算日期之前降级，以便让你有足够的时间归还dvd。

**When downgrading my plan how is my monthly charge calculated?**  
(throw event to change billing)  
You can downgrade your plan at any time during your billing month. You will be charged the new plan price from your next billing date provided you have returned the relevant number of Discs.
If the relevant number of Discs have not been returned by your next billing date we will continue to charge you for the higher value plan. In this event we would recommend returning to the higher value plan to receive the best value for money. You should then downgrade your plan before your next billing date, allowing enough time to return your Discs.

---

## 我可能会因度假而耽搁怎么办？ ##

如果你选择了无限套餐，那你有长达三个月的付款延期。

你每年最多只能有两次账户延期。 例如，如果你有2015-03-13、2015-06-13两次延期，那么你下一次可用的延期只能从2015-03-14开始。（不是2016？）

你可以随时要求账户假期，每次最多持续90天，最短1周。在“付款方式”页面上的下拉框选择起止日期即可。

**What happens if I go on holiday?**  
If you chose an unlimited package, you can take a payment holiday for up to three months.

You will only be able to take two account holidays per year. For example, if you take your first account holiday on 15-03-13 and your second account holiday on 15-06-13, your next account holiday will only be available again from 15-03-14.

You can take an account holiday at any time for a period of up to 90 days (and a minimum of 1 week). Simply use the drop down boxes on the Payment Holiday page to select the date you want your account holiday to start and how long you want it to last. 

---

## 如果我申请了付款延期，那应如何计费 ##

**（抛出事件以暂停计费）**

你的每月付款计划将保持不变。在你的付款延期结束时，我们会顺延你的下一个结算日期，以便考虑你在付款延期内已支付但未使用部分的价值。
例如：（基于订阅价格为14.99元的示例）你当前的结算日期为9月8日。你将在9月8日至10月8日期间支付14.99元的服务费。当你在9月15日开始一个结束于9月20日的付款延期时，你的新结算日期将变为10月13日（因为你已支付5天服务但未使用）。10月8日，我们不会向你收费。而从10月13日开始，你需要支付14.99元。如果你希望从10月13日开始修改结算日期，你可以在付款延期结束后立即进行。

**When taking a payment holiday how is my monthly payment worked out?**  
(throw event to pause billing)  
Your monthly payment will remain the same. At the end of your payment holiday we will delay your next billing date to take account of the value of the service that you have paid for and didn't use during your payment holiday. For example:
(Example based on a plan priced at £14.99)
Your current billing date is on the 8th September. You will be billed £14.99 for service between the 8th September and the 8th October.
On the 15th September you start a payment holiday that will end on the 20th September.
On the 20th September your payment holiday ends. Your new billing date will be 13th October (as there were 5 days service that you had paid for but not used). On 8th October you will not be charged. On 13th October you will be charged £14.99.
If you wish to change your billing date from 13th October you can do so as soon as your payment holiday has ended.

---

## 选择了付款延期结束日后会发生什么？ ##

选择付款延期结束日期后，你将收到一封确认用的电子邮件。请确保为归还dvd留出了足够的时间，因为你的付款延期在我们收到dvd后才会开始。注意：在你的付款延期内，你不会收到任何dvd，但你仍可以登录并修改你的列表，或更改任何必要的信息。

**What happens after I have selected an end date for my payment holiday?**  
After you have selected the end date for your payment holiday you will receive a confirmation e-mail.
Make sure you allow time for the Discs to be returned as your payment holiday will not start until we have received them.
Note: While on your payment holiday you will not be sent any Discs but you will still be able to log in and amend your list or change any details necessary.

---

## 节流/公平使用 ##

**（核心域）**

这是一种被称为“节流”的方法，Netflix对此进行了大量的宣传，并称之为"公平使用"算法。在这种情况下，当最近的物流中心没有所请求的电影时，大批量客户可能享受来自其他替代仓库配送的更大可能性，虽然这样会慢一点。此外，对某一部特定的电影，则不常租的人将比经常租的人更优先获租，然后把电影挪到经常租的人的下一次清单里。对此，Netflix解释说，公平算法的结果很象是节流，总是优先给予不频繁交换dvd的订户。

**Throttling / Fair Use**   
(Core Domain)  
One is the so-called "throttling" approach, which received a fair amount of publicity with regard to Netflix (which refers to the practice as a "fairness algorithm").[3] In this case, high-volume customers may experience a greater likelihood of (slower) shipments from alternative warehouses, when the nearest shipment centre does not have the requested movie. Also, if there is a high demand for a particular movie, it is more likely that an infrequent renter will get priority over the frequent renters, with the latter receiving a movie further down on their queue.
Netflix explains that what looks like throttling is the result of their fairness algorithm which gives priority to subscribers that don't exchange DVDs frequently.
