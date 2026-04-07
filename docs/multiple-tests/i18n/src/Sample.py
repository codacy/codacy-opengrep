import datetime
import locale
import gettext

# Set up gettext (only English & French, but French translations missing some keys)
locales = {
    "en": gettext.translation("messages", localedir="locales", languages=["en"], fallback=True),
    "fr": gettext.translation("messages", localedir="locales", languages=["fr"], fallback=True),
}

current_locale = "en"
_ = locales[current_locale].gettext

orders = [
    {"id": 1, "customer": "Alice", "amount": 1234.56, "date": datetime.date.today()},
    {"id": 2, "customer": "Bob", "amount": 98765.43, "date": datetime.date.today()},
]


def switch_language(lang):
    global _, current_locale
    if lang in locales:
        current_locale = lang
        _ = locales[lang].gettext
    else:
        print(f"Language {lang} not supported, falling back to English")
        current_locale = "en"
        _ = locales["en"].gettext


def add_order(customer, amount):
    today = datetime.date.today()

    # ❌ BAD: Hardcoded English + concatenation
    print("Order for " + customer + " created on " + str(today))

    # ✅ GOOD: Proper i18n message
    print(_("Order for {customer} created on {date}").format(customer=customer, date=today))

    orders.append({"id": len(orders) + 1, "customer": customer, "amount": amount, "date": today})


def list_orders():
    print(_("Order List"))
    print("------------")
    for o in orders:
        # ❌ BAD: Hardcoded date format
        print(f"{o['customer']} | {o['date'].strftime('%m/%d/%Y')} | ${o['amount']:.2f}")

        # ✅ GOOD: Locale-aware formatting
        locale.setlocale(locale.LC_ALL, current_locale)
        formatted_date = o['date'].strftime(locale.nl_langinfo(locale.D_FMT))
        formatted_amount = locale.currency(o['amount'], grouping=True)
        print(f"{o['customer']} | {formatted_date} | {formatted_amount}")


def summary():
    total = sum(o["amount"] for o in orders)

    # ❌ BAD: Hardcoded string
    print("Total Orders: " + str(len(orders)))
    print("Total Revenue: $" + str(total))

    # ✅ GOOD: Localized message
    print(_("Total Orders: {count}").format(count=len(orders)))
    print(_("Total Revenue: {revenue}").format(revenue=locale.currency(total, grouping=True)))


if __name__ == "__main__":
    print(_("Welcome to Order Management System"))

    list_orders()

    add_order("Charlie", 555.75)

    print("\nAfter Adding Order:")
    list_orders()

    summary()

    print("\nSwitching to French (missing translations -> fallback):")
    switch_language("fr")
    list_orders()
