# PhysicalUnits
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) [![build and test](https://github.com/philipp2604/PhysicalUnits/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/philipp2604/PhysicalUnits/actions/workflows/build-and-test.yml) ![GitHub Release](https://img.shields.io/github/v/release/philipp2604/PhysicalUnits) [![NuGet Version](https://img.shields.io/nuget/v/philipp2604.PhysicalUnits)](https://www.nuget.org/packages/philipp2604.PhysicalUnits/)




## Description 
This library allows for enables simple handling of physical quantities and their units as well as unit conversation.

## Download
You can acquire this library either directly via the NuGet package manager or by downloading it from the [NuGet Gallery](https://www.nuget.org/packages/philipp2604.PhysicalUnits/).

## Quick Start
**I recommend having a look at the example project or at the unit tests.**

Example:

```
using PhysicalUnits.Lib.SI.Base;
using static PhysicalUnits.Lib.PhysicalQuantity;


var massInKg = new Mass(10, Mass.Units.Gram, Prefix.Kilo);

var massInmg = mass.GetValue(Prefix.Milli);
var massInPounds = mass.GetValueInUnit(Mass.Units.Pound);
```


## Questions? Problems?
**Feel free to reach out!**

## Progress
This library is wip.  
Currently, only the base SI units are implemented:  
* Amount of substance
* Electrical current
* Length
* Luminous intensity
* Mass
* Temperature
* Time


## Third Party Software / Packages
Please have a look at [THIRD-PARTY-LICENSES](./THIRD-PARTY-LICENSES.md) for all the awesome packages used in this library.

## License
This library is [MIT licensed](./LICENSE.txt).