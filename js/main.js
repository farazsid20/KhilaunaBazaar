// ============= Cart Management =============
let cart = JSON.parse(localStorage.getItem('khilaunaBazaarCart')) || [];

function addToCart(productId, productName, productPrice) {
    const existingItem = cart.find(item => item.id === productId);
    
    if (existingItem) {
        existingItem.quantity += 1;
        showNotification(`${productName} quantity updated!`, 'success');
    } else {
        cart.push({
            id: productId,
            name: productName,
            price: productPrice,
            quantity: 1
        });
        showNotification(`${productName} added to cart!`, 'success');
    }
    
    saveCart();
    updateCartCount();
}

function removeFromCart(productId) {
    cart = cart.filter(item => item.id !== productId);
    saveCart();
    updateCartCount();
    if (typeof loadCart === 'function') {
        loadCart();
    }
}

function updateQuantity(productId, quantity) {
    const item = cart.find(item => item.id === productId);
    if (item) {
        if (quantity <= 0) {
            removeFromCart(productId);
        } else {
            item.quantity = quantity;
            saveCart();
            if (typeof loadCart === 'function') {
                loadCart();
            }
        }
    }
}

function saveCart() {
    localStorage.setItem('khilaunaBazaarCart', JSON.stringify(cart));
}

function updateCartCount() {
    const count = cart.reduce((total, item) => total + item.quantity, 0);
    const cartCountElements = document.querySelectorAll('#cartCount');
    cartCountElements.forEach(element => {
        element.textContent = count;
        if (count > 0) {
            element.style.display = 'inline-block';
        } else {
            element.style.display = 'none';
        }
    });
}

function getCartTotal() {
    return cart.reduce((total, item) => total + (item.price * item.quantity), 0);
}

function getCartCount() {
    return cart.reduce((total, item) => total + item.quantity, 0);
}

// ============= Notification System =============
function showNotification(message, type = 'info') {
    const notification = document.createElement('div');
    notification.className = `alert alert-${type} alert-dismissible fade show position-fixed`;
    notification.style.cssText = 'top: 80px; right: 20px; z-index: 9999; min-width: 300px; max-width: 400px; animation: slideInRight 0.3s ease;';
    notification.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    
    document.body.appendChild(notification);
    
    setTimeout(() => {
        notification.remove();
    }, 3000);
}

// ============= Scroll Animations =============
const observerOptions = {
    threshold: 0.1,
    rootMargin: '0px 0px -50px 0px'
};

const observer = new IntersectionObserver(function(entries) {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate-on-scroll');
            observer.unobserve(entry.target);
        }
    });
}, observerOptions);

document.addEventListener('DOMContentLoaded', function() {
    // Observe all cards and feature boxes for animation
    document.querySelectorAll('.card, .feature-box').forEach(element => {
        observer.observe(element);
    });
    
    // Initialize tooltips if any
    initializeTooltips();
});

// ============= Tooltips =============
function initializeTooltips() {
    const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });
}

// ============= Product Data =============
const productDatabase = {
    'action-figures': [
        { id: 1, name: 'Space Explorer Robot', price: 29.99, rating: 4.5, description: 'Advanced robot with LED lights and sound effects', image: 'https://via.placeholder.com/400x300/667eea/ffffff?text=Space+Robot' },
        { id: 2, name: 'Superhero Action Set', price: 39.99, rating: 4.8, description: 'Set of 5 superhero figures with accessories', image: 'https://via.placeholder.com/400x300/FF6B6B/ffffff?text=Superhero+Set' },
        { id: 3, name: 'Dinosaur T-Rex', price: 24.99, rating: 4.3, description: 'Realistic dinosaur figure with movable joints', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Dinosaur' },
        { id: 4, name: 'Knight with Horse', price: 34.99, rating: 4.6, description: 'Medieval knight figure with armor and horse', image: 'https://via.placeholder.com/400x300/696969/ffffff?text=Knight' },
        { id: 5, name: 'Ninja Warrior Set', price: 27.99, rating: 4.4, description: 'Set of ninja warriors with weapons', image: 'https://via.placeholder.com/400x300/1C1C1C/ffffff?text=Ninja+Set' },
        { id: 6, name: 'Pirate Captain', price: 26.99, rating: 4.5, description: 'Pirate figurine with pirate ship accessories', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Pirate' }
    ],
    'dolls': [
        { id: 7, name: 'Princess Doll Set', price: 34.99, rating: 4.8, description: 'Beautiful princess doll with royal outfit', image: 'https://via.placeholder.com/400x300/FFD700/ffffff?text=Princess' },
        { id: 8, name: 'Baby Doll with Accessories', price: 32.99, rating: 4.7, description: 'Soft baby doll with clothing and accessories', image: 'https://via.placeholder.com/400x300/FFB6C1/ffffff?text=Baby+Doll' },
        { id: 9, name: 'Fashion Model Doll', price: 28.99, rating: 4.5, description: 'Fashion doll with trendy outfits', image: 'https://via.placeholder.com/400x300/FF69B4/ffffff?text=Fashion+Doll' },
        { id: 10, name: 'Ballerina Doll', price: 31.99, rating: 4.6, description: 'Graceful ballerina doll in pink tutu', image: 'https://via.placeholder.com/400x300/FF1493/ffffff?text=Ballerina' },
        { id: 11, name: 'Mermaid Doll', price: 29.99, rating: 4.7, description: 'Fantasy mermaid doll with tail and crown', image: 'https://via.placeholder.com/400x300/00CED1/ffffff?text=Mermaid' },
        { id: 12, name: 'Doctor Doll Set', price: 33.99, rating: 4.4, description: 'Career doll set with medical accessories', image: 'https://via.placeholder.com/400x300/4169E1/ffffff?text=Doctor' }
    ],
    'building-blocks': [
        { id: 13, name: 'Mega Building Blocks', price: 49.99, rating: 4.6, description: '500-piece building block set', image: 'https://via.placeholder.com/400x300/FFD700/000000?text=Building+Blocks' },
        { id: 14, name: 'Castle Construction Kit', price: 44.99, rating: 4.7, description: 'Build your own medieval castle', image: 'https://via.placeholder.com/400x300/696969/ffffff?text=Castle' },
        { id: 15, name: 'City Builder Set', price: 39.99, rating: 4.5, description: 'Create a complete city with houses and roads', image: 'https://via.placeholder.com/400x300/C0C0C0/000000?text=City+Builder' },
        { id: 16, name: 'Space Station Kit', price: 54.99, rating: 4.8, description: 'Build an intergalactic space station', image: 'https://via.placeholder.com/400x300/4B0082/ffffff?text=Space+Station' },
        { id: 17, name: 'Bridge Construction Set', price: 35.99, rating: 4.4, description: 'Engineering building set', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Bridge' },
        { id: 18, name: 'Dinosaur World Blocks', price: 42.99, rating: 4.6, description: 'Build dinosaur habitats', image: 'https://via.placeholder.com/400x300/228B22/ffffff?text=Dino+World' }
    ],
    'outdoor-toys': [
        { id: 19, name: 'Outdoor Sports Kit', price: 39.99, rating: 4.7, description: 'Complete set with badminton, frisbee, and more', image: 'https://via.placeholder.com/400x300/228B22/ffffff?text=Sports+Kit' },
        { id: 20, name: 'Roller Skates', price: 44.99, rating: 4.5, description: 'Adjustable roller skates for kids', image: 'https://via.placeholder.com/400x300/FF4500/ffffff?text=Roller+Skates' },
        { id: 21, name: 'Skateboard', price: 49.99, rating: 4.6, description: 'Professional small skateboard', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Skateboard' },
        { id: 22, name: 'Jump Rope Set', price: 19.99, rating: 4.8, description: 'Colorful jump rope with counter', image: 'https://via.placeholder.com/400x300/FF69B4/000000?text=Jump+Rope' },
        { id: 23, name: 'Lawn Bowling Set', price: 34.99, rating: 4.4, description: 'Bowling pins and balls for lawn', image: 'https://via.placeholder.com/400x300/228B22/ffffff?text=Bowling' },
        { id: 24, name: 'Kite Flying Kit', price: 24.99, rating: 4.7, description: 'Colorful kite with flying string', image: 'https://via.placeholder.com/400x300/FFD700/000000?text=Kite' }
    ],
    'board-games': [
        { id: 25, name: 'Chess Master Board', price: 29.99, rating: 4.6, description: 'Elegant chess set for kids', image: 'https://via.placeholder.com/400x300/696969/ffffff?text=Chess' },
        { id: 26, name: 'Monopoly Junior', price: 24.99, rating: 4.7, description: 'Kid-friendly version of Monopoly', image: 'https://via.placeholder.com/400x300/FF0000/ffffff?text=Monopoly' },
        { id: 27, name: 'Candy Land Adventure', price: 19.99, rating: 4.8, description: 'Classic candy-themed board game', image: 'https://via.placeholder.com/400x300/FFD700/000000?text=Candy+Land' },
        { id: 28, name: 'Snake and Ladders Deluxe', price: 22.99, rating: 4.5, description: 'Wooden board game set', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Snake+Ladders' },
        { id: 29, name: 'Memory Card Game', price: 17.99, rating: 4.9, description: 'Classic memory matching game', image: 'https://via.placeholder.com/400x300/4169E1/ffffff?text=Memory' },
        { id: 30, name: 'Puzzle Adventure Game', price: 26.99, rating: 4.6, description: 'Strategy and puzzle combined', image: 'https://via.placeholder.com/400x300/9370DB/ffffff?text=Puzzle' }
    ],
    'stuffed-animals': [
        { id: 31, name: 'Teddy Bear', price: 22.99, rating: 4.9, description: 'Soft cuddly teddy bear', image: 'https://via.placeholder.com/400x300/8B4513/ffffff?text=Teddy+Bear' },
        { id: 32, name: 'Unicorn Plush', price: 26.99, rating: 4.8, description: 'Magical rainbow unicorn', image: 'https://via.placeholder.com/400x300/FF69B4/ffffff?text=Unicorn' },
        { id: 33, name: 'Dinosaur Plush Toy', price: 24.99, rating: 4.7, description: 'Soft dinosaur friend', image: 'https://via.placeholder.com/400x300/90EE90/000000?text=Dino+Plush' },
        { id: 34, name: 'Cat Kitten Plush', price: 21.99, rating: 4.8, description: 'Adorable kitten plush toy', image: 'https://via.placeholder.com/400x300/FFB347/000000?text=Kitten' },
        { id: 35, name: 'Lion King Plush', price: 28.99, rating: 4.9, description: 'Roaring lion plush', image: 'https://via.placeholder.com/400x300/FFD700/000000?text=Lion' },
        { id: 36, name: 'Panda Bear Plush', price: 23.99, rating: 4.8, description: 'Cute bamboo-loving panda', image: 'https://via.placeholder.com/400x300/000000/ffffff?text=Panda' }
    ]
};

// ============= Load Products =============
function loadProductsByCategory(category) {
    const products = productDatabase[category] || [];
    const container = document.getElementById('productContainer');
    
    if (!container) return;
    
    container.innerHTML = '';
    
    if (products.length === 0) {
        container.innerHTML = '<div class="alert alert-warning w-100">No products found in this category.</div>';
        return;
    }
    
    products.forEach((product, index) => {
        const colors = ['#667eea', '#764ba2', '#f093fb', '#4facfe', '#00f2fe', '#43e97b'];
        const bgColor = colors[index % colors.length];
        
        const html = `
            <div class="col-md-6 col-lg-4 col-xl-3">
                <div class="card h-100 shadow-sm border-0 product-card-hover">
                    <div class="img-placeholder" style="background: linear-gradient(135deg, ${bgColor} 0%, ${bgColor}cc 100%); padding: 0; overflow: hidden;">
                        <img src="${product.image}" alt="${product.name}" style="width: 100%; height: 100%; object-fit: cover; display: block;">
                    </div>
                    <div class="card-body d-flex flex-column">
                        <h6 class="card-title" data-bs-toggle="tooltip" title="${product.description}">${product.name}</h6>
                        <p class="text-muted small flex-grow-1">${product.description}</p>
                        <div class="mb-2">
                            <span class="badge bg-success">★ ${product.rating}</span>
                        </div>
                        <h5 class="text-primary mb-3">₹${product.price.toFixed(2)}</h5>
                        <div class="d-grid gap-2">
                            <button class="btn btn-primary btn-sm" onclick="addToCart(${product.id}, '${product.name}', ${product.price})">
                                <i class="fas fa-shopping-cart"></i> Add to Cart
                            </button>
                            <button class="btn btn-outline-primary btn-sm" onclick="viewProductDetail(${product.id}, '${category}')">
                                <i class="fas fa-eye"></i> View Details
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        `;
        container.innerHTML += html;
    });
    
    // Initialize tooltips for new elements
    initializeTooltips();
}

function viewProductDetail(productId, category) {
    // Store in sessionStorage for retrieval on detail page
    const products = productDatabase[category];
    const product = products.find(p => p.id === productId);
    
    if (product) {
        sessionStorage.setItem('selectedProduct', JSON.stringify(product));
        window.location.href = 'product-detail.html';
    }
}

// ============= Form Validations =============
function validateEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}

function validatePhone(phone) {
    const phoneRegex = /^[\d\s\-\+\(\)]+$/;
    return phoneRegex.test(phone) && phone.length >= 10;
}

function validateCardNumber(cardNumber) {
    const cardRegex = /^[\d\s\-]*$/;
    return cardRegex.test(cardNumber) && cardNumber.replace(/\D/g, '').length === 16;
}

// ============= Smooth Scroll =============
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        const href = this.getAttribute('href');
        if (href !== '#' && document.querySelector(href)) {
            e.preventDefault();
            document.querySelector(href).scrollIntoView({
                behavior: 'smooth'
            });
        }
    });
});

// ============= Initialize on Page Load =============
window.addEventListener('load', function() {
    updateCartCount();
});
