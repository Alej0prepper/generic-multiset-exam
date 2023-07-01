test:
	dotnet run --project exam

build:
	dotnet build

zip:
	rm C2XX-NombreApellidoApellido.zip | echo "Nada que eliminar"
	zip -j C2XX-NombreApellidoApellido.zip exam/Exam.cs

archive:
	git archive HEAD . -o exam.zip
	7z a -p -mem=AES256 -tzip exam-protected.zip exam.zip

pdf:
	pandoc Readme.md -o Readme.pdf
