# 💱 Currency Exchange Service & Client App

This project consists of a WCF service (`CurrencyService`) and a C# console client application (`MyClient`) that interact with live financial data from the **National Bank of Poland (NBP)**.

---

## 📦 Overview

The system provides users with real-time access to:

- 💰 Currency exchange rates (Table A & C)
- 🪙 Gold prices (per gram in PLN)
- 🔄 Currency conversion calculations (buy/sell)
- 🔧 Basic WCF test endpoints (data contract demos)

The backend service (`CurrencyService`) connects to the NBP public API using `HttpClient`, while the frontend console app (`MyClient`) consumes this WCF service to display data and perform currency exchange simulations.

---

## 🛠️ Project Structure

### 🔹 `CurrencyService` (WCF)

A Windows Communication Foundation (WCF) service that exposes the following operations:

| Method                | Description                                               |
|----------------------|-----------------------------------------------------------|
| `GetCurrency(string)`| Retrieves mid exchange rate for a specific currency (Table A) |
| `GetTable()`         | Retrieves a full currency exchange table with bid/ask rates (Table C) |
| `GetGold()`          | Gets the latest gold price per gram in PLN                |
| `GetData(int)`       | Returns a simple string for test purposes                 |
| `GetDataUsingDataContract(CompositeType)` | Example method showing WCF data contract handling |

Data is retrieved live from [NBP's official API](https://api.nbp.pl/).

---

### 🔹 `MyClient` (Console App)

A C# console application that:

1. Connects to the `CurrencyService` via WCF.
2. Fetches and displays the full currency exchange table (Table C).
3. Prompts the user to:
   - Select a currency (e.g., USD)
   - Choose to **buy** or **sell**
   - Enter an amount to convert
4. Calculates and displays the value in PLN using the corresponding **bid** or **ask** rate.

---

## 🧭 General User Workflow

### Service-Level (via CurrencyService)

- Request current **gold price**
- Request full **currency exchange table** (with bid/ask rates)
- Request **specific currency rate**
- Use simple **test methods** for service validation

### Client-Level (via Console App)

- App starts and loads the exchange table
- User selects a currency code (e.g., `USD`)
- User chooses to "buy" or "sell"
- User inputs an amount
- App calculates the PLN value and displays the result

---

## 🔧 Technologies Used

- .NET (WCF, Console App)
- C#
- Newtonsoft.Json (for JSON handling)
- NBP Public REST API
- Visual Studio (recommended)

---

## 📌 Example Output

