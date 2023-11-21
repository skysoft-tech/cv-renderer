# SkySoft CV Renderer

This application generates a professional CV (Curriculum Vitae) in PDF format based on the data provided in a JSON file.


## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
  - [Options](#options)
  - [Example](#example)
  - [Photo](#example)
  - [JSON Format](#json-format)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

### Prerequisites

Windows or Linux machine

### Installation

```bash
   git clone https://github.com/yourusername/cv-generator.git
```

## Usage

### Options
`--in`: (required) Specify the input JSON file containing CV data.
`--out`: (optional) Specify the output PDF file. If not provided PDF file will be generated in the same folder with .json file
`--columnWidth`: (optional) Allow to change width for the companies name column

### Example

Generate a CV using the provided example data:

```powershell
.\SkySoft.CvRenderer.Cli.exe --in "cvdata.json"
```

### Photo
Renderer able to download photo from web if it provided as URL address or from the local file system

### JSON Format
The input JSON file should follow the [JSON Resume](https://jsonresume.org/) standard. For more information on the JSON Resume schema, visit https://jsonresume.org/schema/.

## Contributing

If you'd like to contribute to this project, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature: git checkout -b feature-name.
3. Commit your changes: git commit -m 'Add some feature'.
4. Push to the branch: git push origin feature-name.
5. Submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](https://adampritchard.mit-license.org/) file for details.