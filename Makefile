api/build:
	cd api && dotnet restore

frontend/node_modules: frontend/package.json frontend/package-lock.json
	cd frontend && npm install

.PHONY: docker-compose
docker-compose:
	docker-compose up -d

start: frontend/node_modules
	./node_modules/bin/concurrently "cd frontend && npm start" "cd api && dotnet run"